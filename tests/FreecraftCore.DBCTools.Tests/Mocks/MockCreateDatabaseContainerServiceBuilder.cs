using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreecraftCore
{
	public sealed class MockCreateDatabaseContainerServiceBuilder : CreateDatabaseContainerServiceBuilder, IDisposable
	{
		/// <inheritdoc />
		public MockCreateDatabaseContainerServiceBuilder([NotNull] ApplicationConfiguration config, [NotNull] string dbcType, string dbcTestFilePath) 
			: base(config, dbcType)
		{

		}

		/// <inheritdoc />
		public void Dispose()
		{

		}

		//There are issues with messing with the registeration right now of this
		//there are invisible dependencies on stream position. Must be fixed.
		//TODO: Fix invisible stream position dependencies
		/// <inheritdoc />
		/*protected override void RegisterDbcFileReader(ContainerBuilder builder, Type dbcModelType, TypedParameter pathParameter)
		{
			builder.RegisterType(typeof(DBCEntryReader<>).MakeGenericType(dbcModelType))
				.As(typeof(IDbcEntryReader<>).MakeGenericType(dbcModelType))
				.SingleInstance();

			builder.RegisterInstance(MockedFileStream)
				.ExternallyOwned()
				.As<Stream>()
				.SingleInstance();

			builder.RegisterType<DbcStringReader>()
				.As<IDbcStringReadable>()
				.SingleInstance();
		}*/

		/// <inheritdoc />
		protected override void RegisterCreateDatabaseDatabaseService(ServiceCollection serviceCollection)
		{
			//To do testing we just use an inmemory database.
			serviceCollection.AddDbContext<DbContext, DataBaseClientFilesDatabaseContext>(builder =>
			{
				builder.UseInMemoryDatabase("dbc.client");
			});
		}
	}
}
