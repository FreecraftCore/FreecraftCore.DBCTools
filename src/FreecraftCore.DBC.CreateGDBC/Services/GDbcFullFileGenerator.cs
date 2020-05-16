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
	public sealed class GDbcFullFileGenerator<TDbcWriteType> : IDbcFileGenerator<TDbcWriteType>
		where TDbcWriteType : class, IDBCEntryIdentifiable
	{
		private IDbcEntryWriter<TDbcWriteType> EntryWriter { get; }

		private ILogger<GDbcFullFileGenerator<TDbcWriteType>> Logger { get; }

		/// <inheritdoc />
		public GDbcFullFileGenerator([NotNull] IDbcEntryWriter<TDbcWriteType> entryWriter, ILogger<GDbcFullFileGenerator<TDbcWriteType>> logger)
		{
			EntryWriter = entryWriter ?? throw new ArgumentNullException(nameof(entryWriter));
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

			int entrySize = await EntryWriter.WriteContents(entries);
		}
	}
}
