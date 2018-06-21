using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreecraftCore
{
	public sealed class MockedCreateDbcContainerServiceBuilder : CreateDbcContainerServiceBuilder
	{
		private DbContext MockedDatabaseContext { get; }

		/// <inheritdoc />
		public MockedCreateDbcContainerServiceBuilder([NotNull] ApplicationConfiguration config, [NotNull] Type dbcType, [NotNull] DbContext mockedDatabaseContext) 
			: base(config, dbcType)
		{
			MockedDatabaseContext = mockedDatabaseContext ?? throw new ArgumentNullException(nameof(mockedDatabaseContext));
		}

		/// <inheritdoc />
		protected override void RegisterDatabaseServices(ServiceCollection serviceCollection)
		{
			//For testing purposes we want to expose a mocked database
			//So we just register this
			serviceCollection.AddSingleton<DbContext, DbContext>(c => MockedDatabaseContext);
		}
	}
}
