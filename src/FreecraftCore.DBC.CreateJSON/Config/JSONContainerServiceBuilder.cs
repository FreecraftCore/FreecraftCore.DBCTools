using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Overby.Extensions.AsyncBinaryReaderWriter;

namespace FreecraftCore
{
	public sealed class JSONContainerServiceBuilder : CreateDatabaseContainerServiceBuilder
	{
		/// <inheritdoc />
		public JSONContainerServiceBuilder(ApplicationConfiguration config, string dbcType) 
			: base(config, dbcType)
		{

		}

		/// <inheritdoc />
		protected override void RegisterCreateDatabaseDatabaseService(ServiceCollection serviceCollection)
		{
			//We do not need to register database services.
		}

		/// <inheritdoc />
		protected override void RegisterEntryInserter(ContainerBuilder builder, Type modelType, TypedParameter pathParameter)
		{
			//For the JSON generation we just override the entry inserter
			//By registering an inserter that spits out JSON files
			builder.RegisterType(typeof(JSONStreamEntryInserter<>).MakeGenericType(modelType))
				.As(typeof(IDatabaseDbcInsertable<>).MakeGenericType(modelType))
				.InstancePerLifetimeScope()
				.OwnedByLifetimeScope();
			
			//The JSON writing expects a TextWriter
			builder.Register<AsyncBinaryWriter>(context =>
				{
					return new AsyncBinaryWriter(new FileStream(Path.Combine(Config.DiffOutputPath, $"{DbcType}.json"), FileMode.Create, FileAccess.Write));
				})
				.AsSelf()
				.InstancePerLifetimeScope()
				.OwnedByLifetimeScope();
		}

		/// <inheritdoc />
		protected override TypedParameter CreateInputPathParameter()
		{
			return new TypedParameter(typeof(string), $"{Config.DbcOutputPath}/{DbcType}.dbc");
		}
	}
}
