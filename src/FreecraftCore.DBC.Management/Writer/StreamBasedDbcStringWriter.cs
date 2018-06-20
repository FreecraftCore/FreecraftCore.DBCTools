using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Objects that implements <see cref="Stream"/>-based
	/// <see cref="IDbcStringWriter"/>.
	/// </summary>
	public sealed class StreamBasedDbcStringWriter : IDbcStringWriter
	{
		/// <summary>
		/// The DBC string.
		/// </summary>
		public Stream DbcStream { get; }

		//TODO: We should share a univseral serializer for performance reasons.
		/// <summary>
		/// The serializer
		/// </summary>
		private static ISerializerService Serializer { get; } = new SerializerService();

		static StreamBasedDbcStringWriter()
		{
			Serializer.RegisterType<StringDBC>();
			Serializer.Compile();
		}

		/// <inheritdoc />
		public StreamBasedDbcStringWriter([NotNull] Stream dbcStream)
		{
			DbcStream = dbcStream ?? throw new ArgumentNullException(nameof(dbcStream));
		}

		/// <inheritdoc />
		public async Task WriteStringContents([NotNull] IReadOnlyCollection<string> stringsToWrite)
		{
			if(stringsToWrite == null) throw new ArgumentNullException(nameof(stringsToWrite));

			//If none we don't need to write
			if(stringsToWrite.Count == 0)
				return;

			//We should expect that the caller ordered this the way they wanted.
			foreach(string s in stringsToWrite)
			{
				ReadOnlyMemory<byte> asciiBytes = ReadStringAsASCIIBytes(s);

				await DbcStream.WriteAsync(asciiBytes);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static unsafe ReadOnlyMemory<byte> ReadStringAsASCIIBytes(string s)
		{
			//TODO: Can we avoid an allocation here?
			byte[] asciStringBytes = new byte[s.Length];

			Span<byte> bytesSpan = new Span<byte>(asciStringBytes);

			Encoding.ASCII.GetEncoder().GetBytes(s.AsSpan(), bytesSpan, true);

			return new ReadOnlyMemory<byte>(asciStringBytes);
		}
	}
}
