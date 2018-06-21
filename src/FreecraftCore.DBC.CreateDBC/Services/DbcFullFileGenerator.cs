using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FreecraftCore
{
	public sealed class DbcFullFileGenerator<TDbcWriteType> : IDbcFileGenerator<TDbcWriteType>
		where TDbcWriteType : class, IDBCEntryIdentifiable
	{
		private IDbcEntryWriter<TDbcWriteType> EntryWriter { get; }

		private IDbcStringWriter StringWriter { get; }

		private IDbcHeaderWriter HeaderWriter { get; }

		private IStringDatabaseProvider StringDatabaseProvider { get; }

		private ILogger<DbcFullFileGenerator<TDbcWriteType>> Logger { get; }

		/// <inheritdoc />
		public DbcFullFileGenerator([NotNull] IDbcEntryWriter<TDbcWriteType> entryWriter, [NotNull] IDbcStringWriter stringWriter, [NotNull] IDbcHeaderWriter headerWriter, [NotNull] IStringDatabaseProvider stringDatabaseProvider, ILogger<DbcFullFileGenerator<TDbcWriteType>> logger)
		{
			EntryWriter = entryWriter ?? throw new ArgumentNullException(nameof(entryWriter));
			StringWriter = stringWriter ?? throw new ArgumentNullException(nameof(stringWriter));
			HeaderWriter = headerWriter ?? throw new ArgumentNullException(nameof(headerWriter));
			StringDatabaseProvider = stringDatabaseProvider ?? throw new ArgumentNullException(nameof(stringDatabaseProvider));
			Logger = logger;
		}

		/// <inheritdoc />
		public async Task WriteEntries(IReadOnlyCollection<TDbcWriteType> entries)
		{
			//The reason we don't do anything if we encounter no entires
			//is someone could have a partial database. It is not their fault if they don't want to
			//maintain some DBC types
			//So we must just skip writing emptyones
			if(entries.Count == 0)
			{
				if(Logger.IsEnabled(LogLevel.Warning))
					Logger.LogWarning($"Skipping TableType: {entries.Count} because it has no entries. If this is not desired you must populate the table somehow.");

				return;
			}

			if(Logger.IsEnabled(LogLevel.Information))
				Logger.LogDebug($"Writing: {entries.Count} Type: {typeof(TDbcWriteType).Name}");

			//TODO: Make this more efficient
			DbcStringDatabase stringDatabase = StringDatabaseProvider.BuildDatabase();

			//We must move the writer ahead to leave room for the header
			//which we must write at the end.
			//TODO: This is a hack, we put a fake header in the stream at first so we can rewrite it later.
			await HeaderWriter.WriteHeader(new DBCHeader(1, 1, 1, 1));
			int entrySize = await EntryWriter.WriteContents(entries);

			//We have to order this otherwise the strings may be out of order based on their
			//offset that we set the original members to.
			var stringCollection = stringDatabase.StringToOffsetMap
				.OrderBy(pair => pair.Value)
				.Select(s => s.Key)
				.ToArray();

			await StringWriter.WriteStringContents(stringCollection);

			DBCHeader header = new DBCHeader(entries.Count, entrySize / sizeof(int), entrySize, (int)stringDatabase.Currentoffset);

			if(Logger.IsEnabled(LogLevel.Debug))
				Logger.LogDebug($"Generating Header for Type: {typeof(TDbcWriteType).Name} with HeaderValue: {header}");

			//Now write the real header
			await HeaderWriter.WriteHeader(header);
		}
	}
}
