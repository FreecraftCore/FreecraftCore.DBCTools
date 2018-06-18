using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class DbcEntryWriter<TDBCEntryType>
		where TDBCEntryType : IDBCEntryIdentifiable
	{
		public Stream DbcStream { get; }

		//TODO: We should share a univseral serializer for performance reasons.

		/// <summary>
		/// The serializer
		/// </summary>
		private static ISerializerService Serializer { get; } = new SerializerService();

		static DbcEntryWriter()
		{
			Serializer.RegisterType<DBCHeader>();
			Serializer.RegisterType<StringDBC>();
			Serializer.RegisterType<TDBCEntryType>();
			Serializer.Compile();
		}

		/// <inheritdoc />
		public DbcEntryWriter([NotNull] Stream dbcStream)
		{
			DbcStream = dbcStream ?? throw new ArgumentNullException(nameof(dbcStream));
		}

		public async Task WriteEntries([NotNull] IReadOnlyCollection<TDBCEntryType> entries)
		{
			if(entries == null) throw new ArgumentNullException(nameof(entries));

			//We actually have to serialize the collection first.
			//So we move the stream forward so we can write the header afterwards
			DbcStream.Position = DBCHeader.HeaderSize;

			//This is kinda hacky, we serialize the first one like this because
			//we want to know the size of the entry. Since it's not a struct or marshalable/bittable
			//we HAVE to do this
			byte[] bytes = Serializer.Serialize(entries.First());

			int entrySize = bytes.Length;
			await DbcStream.WriteAsync(bytes, 0, entrySize);

			foreach(TDBCEntryType entry in entries.Skip(1))
			{
				await DbcStream.WriteAsync(Serializer.Serialize(entry));
			}

			//Now reset the position of the stream so we can build the header.
			DbcStream.Position = 0;

			//TODO: Handle strings
			//TODO: Does field count include key?
			DBCHeader header = new DBCHeader(entries.Count, entrySize / sizeof(int), entrySize, 0);

			await DbcStream.WriteAsync(Serializer.Serialize(header));
		}
	}
}
