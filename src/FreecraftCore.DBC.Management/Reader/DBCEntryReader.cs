using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Nito.AsyncEx;

namespace FreecraftCore
{
	/// <summary>
	/// DBC file/stream reader.
	/// Providing ability to read/parse a DBC file from a stream.
	/// </summary>
	/// <typeparam name="TDBCEntryType">The entry type.</typeparam>
	public sealed class DBCEntryReader<TDBCEntryType> : DbcReaderBase, IDbcEntryReader<TDBCEntryType>
		where TDBCEntryType : IDBCEntryIdentifiable
	{
		public ILogger<DBCEntryReader<TDBCEntryType>> Logger { get; }

		//TODO: We should share a univseral serializer for performance reasons.

		/// <summary>
		/// The serializer
		/// </summary>
		private static ISerializerService Serializer { get; } = new SerializerService();

		static DBCEntryReader()
		{
			Serializer.RegisterType<DBCHeader>();
			Serializer.RegisterType<StringDBC>();
			Serializer.RegisterType<TDBCEntryType>();
			Serializer.Compile();
		}

		/// <inheritdoc />
		public DBCEntryReader([NotNull] Stream dbcStream, ILogger<DBCEntryReader<TDBCEntryType>> logger) 
			: base(dbcStream)
		{
			Logger = logger;
		}

		public async Task<ParsedDBCFile<TDBCEntryType>> Parse()
		{
			DBCHeader header = null;
			try
			{
				header = await ReadDBCHeader(Serializer);
			}
			catch(Exception e)
			{
				if(Logger.IsEnabled(LogLevel.Error))
					Logger.LogError($"Failed to read {nameof(DBCHeader)} for Type: {typeof(TDBCEntryType).Name}. Exception: {e.Message} \n\n Stack: {e.StackTrace}");

				throw;
			}

			//The below is from the: https://github.com/TrinityCore/SpellWork/blob/master/SpellWork/DBC/DBCReader.cs
			if(!header.IsDBC)
				throw new InvalidOperationException($"Failed to load DBC for DBC Type: {typeof(TDBCEntryType)} Signature: {header.Signature}");

			ConfiguredTaskAwaitable<Dictionary<uint, TDBCEntryType>> dbcEntry = ReadDBCEntryBlock(header)
				.ConfigureAwait(false);

			//TODO: Implement DBC string reading
			return new ParsedDBCFile<TDBCEntryType>(await dbcEntry);
		}

		private async Task<Dictionary<uint, TDBCEntryType>> ReadDBCEntryBlock(DBCHeader header)
		{
			//Guessing the size here, no way to know.
			Dictionary<uint, TDBCEntryType> entryMap = new Dictionary<uint, TDBCEntryType>(header.RecordsCount);

			byte[] bytes = new byte[header.RecordSize * header.RecordsCount];

			//Lock for safety, we don't want anyone else accessing the stream while we read it.
			await ReadBytesIntoArrayFromStream(bytes);

			DefaultStreamReaderStrategy reader = new DefaultStreamReaderStrategy(bytes);

			for(int i = 0; i < header.RecordsCount; i++)
			{
				TDBCEntryType entry = default(TDBCEntryType);
				try
				{
					entry = Serializer.Deserialize<TDBCEntryType>(reader);
				}
				catch(Exception e)
				{
					if(Logger.IsEnabled(LogLevel.Error))
						Logger.LogError($"Encountered error reading entry Type: {typeof(TDBCEntryType).Name} at Entry count: {i} Exception: {e.Message} \n\n Stack: {e.StackTrace}");

					Console.WriteLine($"Encountered error reading entry Type: {typeof(TDBCEntryType).Name} at Entry count: {i} Exception: {e.Message} \n\n Stack: {e.StackTrace}");

					throw;
				}

				entryMap.Add(entry.EntryId, entry);
			}

			return entryMap;
		}
	}
}
