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
		public Task WriteHeader(DBCHeader header)
		{
			return DbcStream.WriteAsync(Serializer.Serialize(header)).AsTask();
		}
	}
}
