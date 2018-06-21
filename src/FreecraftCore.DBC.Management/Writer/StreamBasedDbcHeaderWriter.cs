using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class StreamBasedDbcHeaderWriter : IDbcHeaderWriter
	{
		/// <summary>
		/// The stream to write to.
		/// </summary>
		public Stream DbcStream { get; }

		//TODO: We should share a univseral serializer for performance reasons.
		/// <summary>
		/// The serializer
		/// </summary>
		private static ISerializerService Serializer { get; } = new SerializerService();

		static StreamBasedDbcHeaderWriter()
		{
			Serializer.RegisterType<DBCHeader>();
			Serializer.Compile();
		}

		/// <inheritdoc />
		public StreamBasedDbcHeaderWriter([NotNull] Stream dbcStream)
		{
			DbcStream = dbcStream ?? throw new ArgumentNullException(nameof(dbcStream));
		}

		/// <inheritdoc />
		public async Task WriteHeader(DBCHeader header)
		{
			await DbcStream.FlushAsync();

			//TODO: This is kinda hack, but makes things really easy for callers. Header should always go in front.
			DbcStream.Position = 0;

			byte[] bytes = Serializer.Serialize(header);

			await DbcStream.WriteAsync(bytes, 0, bytes.Length);

			await DbcStream.FlushAsync();
		}
	}
}
