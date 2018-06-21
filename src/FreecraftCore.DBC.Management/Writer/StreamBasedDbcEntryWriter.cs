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
	public sealed class StreamBasedDbcEntryWriter<TDBCEntryType> : IDbcEntryWriter<TDBCEntryType>
		where TDBCEntryType : IDBCEntryIdentifiable
	{
		public Stream DbcStream { get; }

		//TODO: We should share a univseral serializer for performance reasons.
		/// <summary>
		/// The serializer
		/// </summary>
		private static ISerializerService Serializer { get; } = new SerializerService();

		static StreamBasedDbcEntryWriter()
		{
			Serializer.RegisterType<TDBCEntryType>();
			Serializer.Compile();
		}

		/// <inheritdoc />
		public StreamBasedDbcEntryWriter([NotNull] Stream dbcStream)
		{
			DbcStream = dbcStream ?? throw new ArgumentNullException(nameof(dbcStream));
		}

		/// <summary>
		/// Writes the provided <see cref="entries"/>.
		/// Returns the entry size of the serialized entries.
		/// Does NOT write the header.
		/// </summary>
		/// <param name="entries">The entries to write.</param>
		/// <returns>The entry size. (size * <see cref="entries"/> = the total size written)</returns>
		public async Task<int> WriteContents([NotNull] IReadOnlyCollection<TDBCEntryType> entries)
		{
			if(entries == null) throw new ArgumentNullException(nameof(entries));

			//This is kinda hacky, we serialize the first one like this because
			//we want to know the size of the entry. Since it's not a struct or marshalable/bittable
			//we HAVE to do this
			byte[] bytes = Serializer.Serialize(entries.First());

			int entrySize = bytes.Length;
			await DbcStream.WriteAsync(bytes, 0, entrySize);

			foreach(TDBCEntryType entry in entries.Skip(1))
			{
				bytes = Serializer.Serialize(entry);
				await DbcStream.WriteAsync(bytes, 0, bytes.Length);
			}

			return entrySize;
		}
	}
}
