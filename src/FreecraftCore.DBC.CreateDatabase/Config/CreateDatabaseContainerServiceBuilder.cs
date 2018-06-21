using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace FreecraftCore
{
	public class CreateDatabaseContainerServiceBuilder
	{
		private ApplicationConfiguration Config { get; }

		private string DbcType { get; }

		/// <inheritdoc />
		public CreateDatabaseContainerServiceBuilder([NotNull] ApplicationConfiguration config, [NotNull] string dbcType)
		{
			Config = config ?? throw new ArgumentNullException(nameof(config));
			DbcType = dbcType ?? throw new ArgumentNullException(nameof(dbcType));
		}

		/// <summary>
		/// Builds a <see cref="IServiceProvider"/> that registers
		/// <see cref="IDbcTargetFillable"/> which is the only service you should
		/// request from the container. This service will handle all complex
		/// logic for inserting and saving to the database. This is done so that support
		/// for 50 different DBC models and tables can be handled by one single set of generic services.
		/// </summary>
		/// <param name="dbcType"></param>
		/// <returns></returns>
		public IServiceProvider Build()
		{
			//With only the filename (which is why args will be passed in when this is a tool)
			//we need to be able to know the DBC model type AND we need to know what Types to use
			//to do the handling
			//We always need the TypeConverters so we register them first.
			ContainerBuilder builder = new ContainerBuilder();
			ServiceCollection serviceCollection = new ServiceCollection();
			builder.RegisterTypeConvertersFromAssembly(typeof(Program).Assembly);

			serviceCollection.RegisterDatabaseServices(Config.DatabaseConnectionString);
			Type dbcModelType = new DbcTypeParser().ComputeDbcType(DbcType);

			//TODO: Generic handling
			//We have to do special handling for generic models
			//IDatabaseDbcInsertable<TDBCEntryType>

			TypedParameter pathParameter = new TypedParameter(typeof(string), $"{Config.DbcInputPath}/{DbcType}.dbc");
			//TODO: Support configurable DBC location/path.

			//If it's an open generic model it will mean that it requires string type type args
			//Not requiring this is much simplier, but it is still doable when the model is generic
			if(!dbcModelType.IsGenericTypeDefinition)
				RegisterNonGenericDbcModelServices(builder, dbcModelType, pathParameter);
			else
				RegisterGenericDbcModelServices(builder, dbcModelType, pathParameter);

			builder.RegisterType<DbcFileStringReader>()
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
			serviceCollection.RegisterLoggingServices(Config.LoggingLevel);

			//This takes the ASP/Core service collection and pushes it all into AutoFac.
			builder.Populate(serviceCollection);

			return new AutofacServiceProvider(builder.Build());
		}

		/// <summary>
		/// Similar to <see cref="RegisterNonGenericDbcModelServices"/> but handles the cases
		/// where a TStringType generic type arg may need to be handled and dealt with.
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="dbcModelType"></param>
		/// <param name="pathParameter"></param>
		private void RegisterGenericDbcModelServices([NotNull] ContainerBuilder builder, [NotNull] Type dbcModelType, [NotNull] TypedParameter pathParameter)
		{
			if(builder == null) throw new ArgumentNullException(nameof(builder));
			if(dbcModelType == null) throw new ArgumentNullException(nameof(dbcModelType));
			if(pathParameter == null) throw new ArgumentNullException(nameof(pathParameter));

			GenericDbcModelAttribute genericAttri = dbcModelType.GetCustomAttribute<GenericDbcModelAttribute>();

			if(genericAttri == null)
				throw new InvalidOperationException($"Encountered generic Model: {dbcModelType.Name} that did not have {nameof(GenericDbcModelAttribute)} marked.");

			//We can use the model attributes Types for the purposes of registeration
			//and we trust that they are correct.
			//We supply it he database model type because that is what the inserter should know about.
			RegisterEntryInserter(builder, genericAttri.ClosedGenericForDatabase, pathParameter);
			RegisterDbcFileReader(builder, genericAttri.ClosedGenericForFile, pathParameter);

			//We actually use the DBC model file type here. This type has a dependency on an inserter
			//of that generic parameter so it will find the above inserter does not work.
			//To handle this we register a type specific to generic handlers
			RegisterFileToDatabaseConverter(builder, genericAttri.ClosedGenericForFile);

			//This will be the IDatabaseDbcInsertable<TDBCFileType> that the above converter looks for
			//This itself will dispatch to the one registered in RegisterEntryInserter
			builder.RegisterType(typeof(ConvertRequiredDatabaseEntryInserterDecorator<,>)
					.MakeGenericType(genericAttri.ClosedGenericForFile, genericAttri.ClosedGenericForDatabase))
				.AsImplementedInterfaces()
				.SingleInstance();

			//We also need the generic converter too, which is only needed when it's generic.
			builder.RegisterType(typeof(DbcRefToStringTypeConverter<,>).MakeGenericType(genericAttri.ClosedGenericForFile, genericAttri.ClosedGenericForDatabase))
				.AsImplementedInterfaces()
				.SingleInstance();
		}

		private void RegisterNonGenericDbcModelServices([NotNull] ContainerBuilder builder, [NotNull] Type dbcModelType, [NotNull] TypedParameter pathParameter)
		{
			if(builder == null) throw new ArgumentNullException(nameof(builder));
			if(dbcModelType == null) throw new ArgumentNullException(nameof(dbcModelType));
			if(pathParameter == null) throw new ArgumentNullException(nameof(pathParameter));

			RegisterEntryInserter(builder, dbcModelType, pathParameter);
			RegisterDbcFileReader(builder, dbcModelType, pathParameter);

			//This is not a type converter, it converts to the SQL table.
			RegisterFileToDatabaseConverter(builder, dbcModelType);
		}

		private void RegisterFileToDatabaseConverter(ContainerBuilder builder, Type dbcModelType)
		{
			builder.RegisterType(typeof(DbcDatabaseFileToTableConverter<>).MakeGenericType(dbcModelType))
				.AsImplementedInterfaces()
				.SingleInstance();
		}

		protected virtual void RegisterDbcFileReader(ContainerBuilder builder, Type dbcModelType, TypedParameter pathParameter)
		{
			builder.RegisterType(typeof(GenericDbcFileEntryReader<>).MakeGenericType(dbcModelType))
				.As(typeof(IDbcEntryReader<>).MakeGenericType(dbcModelType))
				.SingleInstance()
				.WithParameter(pathParameter);
		}

		private void RegisterEntryInserter([NotNull] ContainerBuilder builder, [NotNull] Type modelType, [NotNull] TypedParameter pathParameter)
		{
			if(builder == null) throw new ArgumentNullException(nameof(builder));
			if(modelType == null) throw new ArgumentNullException(nameof(modelType));
			if(pathParameter == null) throw new ArgumentNullException(nameof(pathParameter));

			builder.RegisterType(typeof(GenericDatabaseDBCEntryInserter<>).MakeGenericType(modelType))
				.AsImplementedInterfaces()
				.SingleInstance()
				.WithParameter(pathParameter);
		}
	}
}
