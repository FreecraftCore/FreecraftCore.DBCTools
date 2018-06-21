using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreecraftCore
{
	class Program
	{
		public static ApplicationConfiguration Config { get; private set; }

		/// <summary>
		/// Builds a <see cref="IServiceProvider"/> that registers
		/// <see cref="IDbcTargetFillable"/> which is the only service you should
		/// request from the container. This service will handle all complex
		/// logic for building the DBC files and saving. This is done so that support
		/// for 200 different DBC models and tables can be handled by one single set of generic services.
		/// </summary>
		/// <param name="dbcType"></param>
		/// <returns></returns>
		public static IServiceProvider BuildServiceContainerForDbcType([NotNull] Type dbcType, [NotNull] string dbcName)
		{
			if(dbcType == null) throw new ArgumentNullException(nameof(dbcType));
			if(dbcName == null) throw new ArgumentNullException(nameof(dbcName));

			//With only the filename (which is why args will be passed in when this is a tool)
			//we need to be able to know the DBC model type AND we need to know what Types to use
			//to do the handling
			//We always need the TypeConverters so we register them first.
			ContainerBuilder builder = new ContainerBuilder();
			ServiceCollection serviceCollection = new ServiceCollection();
			builder.RegisterTypeConvertersFromAssembly(typeof(Program).Assembly);
			serviceCollection.RegisterDatabaseServices(Config.DatabaseConnectionString);
			serviceCollection.RegisterLoggingServices(Config.LoggingLevel);

			builder.RegisterType<StreamBasedDbcHeaderWriter>()
				.AsImplementedInterfaces()
				.SingleInstance();

			builder.RegisterType<StreamBasedDbcStringWriter>()
				.AsImplementedInterfaces()
				.SingleInstance();

			//We cannot use filestream. Otherwise we can create 0 byte empty DBC files in the ouput
			//because sometimes the tables won't be populated.
			builder.RegisterInstance(new MemoryStream())
				.SingleInstance()
				.As<Stream>();

			//If it's an open generic model it will mean that it requires string type type args
			//Not requiring this is much simplier, but it is still doable when the model is generic
			if(!dbcType.IsGenericTypeDefinition)
				RegisterNonGenericDbcModelServices(builder, dbcType);
			else
				RegisterGenericDbcModelServices(builder, dbcType);

			//This takes the ASP/Core service collection and pushes it all into AutoFac.
			builder.Populate(serviceCollection);
			return new AutofacServiceProvider(builder.Build());
		}

		private static void RegisterGenericDbcModelServices(ContainerBuilder builder, Type dbcType)
		{
			//TODO: Move this to DbcTypeParser
			GenericDbcModelAttribute genericAttri = dbcType.GetCustomAttribute<GenericDbcModelAttribute>();

			if(genericAttri == null)
				throw new InvalidOperationException($"Encountered generic Model: {dbcType.Name} that did not have {nameof(GenericDbcModelAttribute)} marked.");

			//Must be for the database model type
			//it reads the DB model type from the table
			builder.RegisterType(typeof(DatabaseDbcEntryReader<>).MakeGenericType(genericAttri.ClosedGenericForDatabase))
				.AsImplementedInterfaces()
				.SingleInstance();
			
			//Generic models need string handling because that is why they are generic.
			builder.RegisterType<DbcStringDatabaseOffsetGenerator>()
				.As<IStringDatabaseProvider>()
				.As<IDbcOffsetGenerator>()
				.SingleInstance();

			//For file type
			builder.RegisterType(typeof(DbcFullFileGenerator<>).MakeGenericType(genericAttri.ClosedGenericForFile))
				.As(typeof(IDbcFileGenerator<>).MakeGenericType(genericAttri.ClosedGenericForFile))
				.SingleInstance();

			builder.RegisterType(typeof(StreamBasedDbcEntryWriter<>).MakeGenericType(genericAttri.ClosedGenericForFile))
				.As(typeof(IDbcEntryWriter<>).MakeGenericType(genericAttri.ClosedGenericForFile))
				.SingleInstance();

			builder.RegisterType(typeof(DbcFullFileGenerator<>).MakeGenericType(genericAttri.ClosedGenericForFile))
				.As(typeof(IDbcFileGenerator<>).MakeGenericType(genericAttri.ClosedGenericForFile))
				.SingleInstance();

			//GenericDbcFileGeneratorFillable<TDbcFileType, TDbcEntryType>
			builder.RegisterType(typeof(GenericDbcFileGeneratorFillable<,>).MakeGenericType(genericAttri.ClosedGenericForFile, genericAttri.ClosedGenericForDatabase))
				.As<IDbcTargetFillable>()
				.SingleInstance();

			//We also have to register a type converter from the table to the file type
			builder.RegisterType(typeof(DbcStringToRefTypeConverter<,>).MakeGenericType(genericAttri.ClosedGenericForDatabase, genericAttri.ClosedGenericForFile))
				.As(typeof(ITypeConverterProvider<,>).MakeGenericType(genericAttri.ClosedGenericForDatabase, genericAttri.ClosedGenericForFile))
				.SingleInstance();
		}

		private static void RegisterNonGenericDbcModelServices(ContainerBuilder builder, Type dbcType)
		{
			builder.RegisterType(typeof(DatabaseDbcEntryReader<>).MakeGenericType(dbcType))
				.AsImplementedInterfaces()
				.SingleInstance();

			//non-generic means no string handling
			//because ALL string-based models are generic.
			builder.RegisterType<NoStringsStringDatabaseProvider>()
				.As<IStringDatabaseProvider>()
				.SingleInstance();

			builder.RegisterType(typeof(StreamBasedDbcEntryWriter<>).MakeGenericType(dbcType))
				.As(typeof(IDbcEntryWriter<>).MakeGenericType(dbcType))
				.SingleInstance();

			builder.RegisterType(typeof(DbcFullFileGenerator<>).MakeGenericType(dbcType))
				.As(typeof(IDbcFileGenerator<>).MakeGenericType(dbcType))
				.SingleInstance();

			builder.RegisterType(typeof(NonGenericDbcFileGeneratorFillable<>).MakeGenericType(dbcType))
				.As<IDbcTargetFillable>()
				.SingleInstance();
		}

		static async Task Main(string[] args)
		{
			//Try to load configuration file
			Config = new ApplicationConfigurationLoader().BuildConfigFile();

			DbcTypeParser dbcTypeParser = new DbcTypeParser();

			//For each implement DBCType we should try to build a DBC file for it.
			foreach(Type dbcType in dbcTypeParser.ComputeAllKnownDbcTypes())
			{
				string dbcName = dbcTypeParser.GetDbcName(dbcType);
				IServiceProvider provider = BuildServiceContainerForDbcType(dbcType, dbcName);

				using(IServiceScope scope = provider.CreateScope())
				{
					IDbcTargetFillable fillable = scope.ServiceProvider.GetService<IDbcTargetFillable>();

					await fillable.FillAsync();

					using(Stream ms = scope.ServiceProvider.GetRequiredService<Stream>())
					{
						//It is possible nothing has been written, this is kinda hacky to put this
						//and leak this in a couple places. But it means no entires were found.
						if(ms.Length == 0)
							continue;

						//Once everything has been filled we should create the file
						using(FileStream fs = new FileStream($"{Config.DbcOutputPath}/{dbcName}.dbc", FileMode.Create, FileAccess.Write))
						{
							await ms.CopyToAsync(fs);
						}
					}
				}
			}

			Console.ReadKey();
		}
	}
}
