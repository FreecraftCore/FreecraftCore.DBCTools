using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace FreecraftCore
{
	public sealed class DbcDatabaseFileToTableConverter<TDBCEntryType> : IDbcTargetFillable
		where TDBCEntryType : IDBCEntryIdentifiable
	{
		/// <summary>
		/// Object that facilitates the inserting of the entries.
		/// </summary>
		private IDatabaseDbcInsertable<TDBCEntryType> Inserter { get; }

		/// <summary>
		/// The object that reads the DBC data.
		/// </summary>
		private IDbcEntryReader<TDBCEntryType> DbcReader { get; }

		private ILogger<DbcDatabaseFileToTableConverter<TDBCEntryType>> Logger { get; }

		/// <inheritdoc />
		public DbcDatabaseFileToTableConverter([NotNull] IDatabaseDbcInsertable<TDBCEntryType> inserter, [NotNull] IDbcEntryReader<TDBCEntryType> dbcReader, [NotNull] ILogger<DbcDatabaseFileToTableConverter<TDBCEntryType>> logger)
		{
			Inserter = inserter ?? throw new ArgumentNullException(nameof(inserter));
			DbcReader = dbcReader ?? throw new ArgumentNullException(nameof(dbcReader));
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		/// <inheritdoc />
		public void Fill()
		{
			FillAsync().Wait();
		}

		/// <inheritdoc />
		public async Task FillAsync()
		{
			if(Logger.IsEnabled(LogLevel.Information))
				Logger.LogInformation($"Converting DBC file: {typeof(TDBCEntryType).Name} to database table.");

			ParsedDBCFile<TDBCEntryType> dbc = await DbcReader.Parse();

			if(dbc == null)
				throw new InvalidOperationException($"Failed to parse DBC for Type: {typeof(TDBCEntryType).Name}");

			await Inserter.InsertEntriesAsync(dbc.RecordDatabase.Values.ToArray());
		}
	}
}
