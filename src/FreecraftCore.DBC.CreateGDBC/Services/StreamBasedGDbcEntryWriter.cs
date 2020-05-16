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
	/// <summary>
	/// <see cref="IDbcEntryWriter{TDBCEntryType}"/> implementation for
	/// GDBC (not DBC).
	/// </summary>
	/// <typeparam name="TDBCEntryType"></typeparam>
	public sealed class StreamBasedGDbcEntryWriter<TDBCEntryType> : IDbcEntryWriter<TDBCEntryType>
		where TDBCEntryType : IDBCEntryIdentifiable
	{
		public Stream DbcStream { get; }

		//TODO: We should share a univseral serializer for performance reasons.
		/// <summary>
		/// The serializer
		/// </summary>
		private static ISerializerService Serializer { get; } = new SerializerService();

		static StreamBasedGDbcEntryWriter()
		{
			Serializer.RegisterType<TDBCEntryType>();
			Serializer.RegisterType<GDBCCollection<TDBCEntryType>>();
			Serializer.Compile();
		}

		/// <inheritdoc />
		public StreamBasedGDbcEntryWriter([NotNull] Stream dbcStream)
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

			GDBCCollection<TDBCEntryType> collection = new GDBCCollection<TDBCEntryType>(entries.ToArray());
			byte[] bytes = Serializer.Serialize(collection);

			await DbcStream.WriteAsync(bytes, 0, bytes.Length);

			//Variable
			return 0;
		}
	}
}
