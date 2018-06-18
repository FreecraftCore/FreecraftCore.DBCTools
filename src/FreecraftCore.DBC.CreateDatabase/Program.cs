using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace FreecraftCore
{
	class Program
	{
		/// <summary>
		/// Builds a <see cref="IServiceProvider"/> that registers
		/// <see cref="ITableFillable"/> which is the only service you should
		/// request from the container. This service will handle all complex
		/// logic for inserting and saving to the database. This is done so that support
		/// for 50 different DBC models and tables can be handled by one single set of generic services.
		/// </summary>
		/// <param name="dbcType"></param>
		/// <returns></returns>
		public static IServiceProvider BuildServiceContainerForDbcType(string dbcType)
		{
			//With only the filename (which is why args will be passed in when this is a tool)
			//we need to be able to know the DBC model type AND we need to know what Types to use
			//to do the handling
			//We always need the TypeConverters so we register them first.
			ContainerBuilder builder = new ContainerBuilder();
			ServiceCollection serviceCollection = new ServiceCollection();
			builder.RegisterAssemblyTypes(typeof(Program).Assembly)
				.AsClosedTypesOf(typeof(ITypeConverterProvider<,>))
				.AsImplementedInterfaces();

			RegisterDatabaseServices(serviceCollection);

			//We can scan for the DBC model type knowing the file name.
			Type dbcModelType = typeof(DBCHeader)
				.Assembly
				.GetExportedTypes()
				.First(t => t.GetCustomAttribute<TableAttribute>()?.Name == dbcType);

			//TODO: Generic handling
			//We have to do special handling for generic models
			//IDatabaseDbcInsertable<TDBCEntryType>

			TypedParameter pathParameter = new TypedParameter(typeof(string), $"DBC/{dbcType}.dbc");
			//TODO: Support configurable DBC location/path.
			builder.RegisterType(typeof(GenericDatabaseDBCEntryInserter<>).MakeGenericType(dbcModelType))
				.AsImplementedInterfaces()
				.SingleInstance()
				.WithParameter(pathParameter);

			builder.RegisterType(typeof(GenericDbcFileEntryReader<>).MakeGenericType(dbcModelType))
				.As(typeof(IDbcEntryReader<>).MakeGenericType(dbcModelType))
				.SingleInstance()
				.WithParameter(pathParameter);

			builder.RegisterType(typeof(DbcDatabaseFileToTableConverter<>).MakeGenericType(dbcModelType))
				.AsImplementedInterfaces()
				.SingleInstance();

			builder.RegisterType<DbcStringReader>()
				.As<IDbcStringReadable>()
				.SingleInstance()
				.WithParameter(pathParameter);

			//TODO: Create a parsed string type so this dictionary is not exposed
			//May look odd but some TypeConverters actually need the string database
			//so they can convert from string offset/pointer to the actual string for the database.
			builder.Register<IReadOnlyDictionary<uint, string>>(context =>
				{
					IDbcStringReadable readable = context.Resolve<IDbcStringReadable>();

					//This is blocking
					return readable.ParseOnlyStrings()
						.ConfigureAwait(false)
						.GetAwaiter()
						.GetResult();
				})
				.SingleInstance()
				.As<IReadOnlyDictionary<uint, string>>();

			//TODO: Make logging optional
			RegisterLoggingServices(builder);

			//This takes the ASP/Core service collection and pushes it all into AutoFac.
			builder.Populate(serviceCollection);
			
			return new AutofacServiceProvider(builder.Build());
		}

		//TODO: make this more configurable
		private static ContainerBuilder RegisterLoggingServices(ContainerBuilder builder)
		{
			//ILoggerFactory loggerFactory = new LoggerFactory()
			//	.AddFile($"{"Logs/Dump-{Date}"}-{Guid.NewGuid()}.txt", LogLevel.Trace);

			ILoggerFactory loggerFactory = new LoggerFactory()
				.AddConsole(LogLevel.Debug);

			builder.RegisterInstance(loggerFactory)
				.As<ILoggerFactory>();

			return builder;
		}

		private static IServiceCollection RegisterDatabaseServices(IServiceCollection serviceCollection)
		{
			//TODO: We should support database connection strings in a config file.
			serviceCollection.AddEntityFrameworkMySql();
			serviceCollection.AddDbContext<DbContext, DataBaseClientFilesDatabaseContext>(options =>
			{
				//TODO: When OnConfiguring no longer has this we should renable this
				options.UseMySql("Server=localhost;Database=client.dbc;Uid=root;Pwd=test;", optionsBuilder =>
				{
					optionsBuilder.MaxBatchSize(4000);
					optionsBuilder.MinBatchSize(20);
					optionsBuilder.EnableRetryOnFailure(5);
					optionsBuilder.CommandTimeout(1000);
				});

				options.EnableSensitiveDataLogging();
			});

			return serviceCollection;
		}

		static async Task Main(string[] args)
		{
			//TODO: This is just test code, we want to handle inputs better.
			Console.Write($"Enter DBC Type: ");
			string dbcType = Console.ReadLine();
			IServiceProvider provider = BuildServiceContainerForDbcType(dbcType);

			Stopwatch watch = new Stopwatch();
			watch.Start();
			using(var scope = provider.CreateScope())
			{
				try
				{
					//TODO: We shouldn't check everytime we create a DBC table. Do this elsewhere
					await CreateDatabaseIfNotCreated(scope.ServiceProvider.GetService<DbContext>());

					//This may look silly but we want to support the 50+ DBC types so
					//it needs to be handle magically otherwise we'd have to write code for each one.
					ITableFillable tableFiller = scope.ServiceProvider.GetService<ITableFillable>();

					await tableFiller.FillAsync();
				}
				catch(Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
			}

			watch.Stop();
			Console.WriteLine($"Created Table In Milliseconds: {watch.ElapsedMilliseconds}");

			Console.WriteLine("Press any key!");
			Console.ReadKey();
		}

		private static async Task CreateDatabaseIfNotCreated(DbContext context)
		{
			await context.Database.MigrateAsync();
			await context.Database.EnsureCreatedAsync();
		}
	}
}
