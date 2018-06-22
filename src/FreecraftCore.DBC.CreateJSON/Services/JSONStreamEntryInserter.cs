using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Overby.Extensions.AsyncBinaryReaderWriter;

namespace FreecraftCore
{
	public sealed class JSONStreamEntryInserter<TDbcEntryType> : IDatabaseDbcInsertable<TDbcEntryType> 
		where TDbcEntryType : IDBCEntryIdentifiable
	{
		private AsyncBinaryWriter Writer { get; }

		private ILogger<JSONStreamEntryInserter<TDbcEntryType>> Logger { get; }

		/// <inheritdoc />
		public JSONStreamEntryInserter([NotNull] AsyncBinaryWriter writer, [NotNull] ILogger<JSONStreamEntryInserter<TDbcEntryType>> logger)
		{
			Writer = writer ?? throw new ArgumentNullException(nameof(writer));
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<int> InsertEntriesAsync([NotNull] IReadOnlyCollection<TDbcEntryType> entries)
		{
			//First we should order them, just incase they are not ordered
			TDbcEntryType[] orderedEntries = entries.OrderBy(e => e.EntryId).ToArray();

			//Uses Newtonsoft.JSON to convert to JSON
			string jsonData = JsonConvert.SerializeObject(orderedEntries, Formatting.Indented);

			if(Logger.IsEnabled(LogLevel.Debug))
				Logger.LogDebug($"About to write JSON for Type: {typeof(TDbcEntryType).Name}");

			//We have to use this encoding otherwise it will length-prefix.
			//See: https://stackoverflow.com/questions/1488486/why-does-binarywriter-prepend-gibberish-to-the-start-of-a-stream-how-do-you-avo/1488602
			await Writer.WriteAsync(Encoding.ASCII.GetBytes(jsonData));

			return orderedEntries.Length;
		}
	}
}
