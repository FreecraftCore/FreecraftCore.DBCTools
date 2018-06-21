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
		public FileStream MockedFileStream { get; }

		/// <inheritdoc />
		public MockCreateDatabaseContainerServiceBuilder([NotNull] ApplicationConfiguration config, [NotNull] string dbcType, string dbcTestFilePath) 
			: base(config, dbcType)
		{
			MockedFileStream = new FileStream(dbcTestFilePath, FileMode.Open, FileAccess.Read);
		}

		/// <inheritdoc />
		public void Dispose()
		{
			MockedFileStream.Dispose();
		}

		/// <inheritdoc />
		protected override void RegisterDbcFileReader(ContainerBuilder builder, Type dbcModelType, TypedParameter pathParameter)
		{
			builder.RegisterType(typeof(DBCEntryReader<>).MakeGenericType(dbcModelType))
				.As(typeof(IDbcEntryReader<>).MakeGenericType(dbcModelType))
				.SingleInstance();

			builder.RegisterInstance(MockedFileStream)
				.As<Stream>()
				.SingleInstance();

			builder.RegisterType<DbcStringReader>()
				.As<IDbcStringReadable>()
				.SingleInstance();
		}

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
