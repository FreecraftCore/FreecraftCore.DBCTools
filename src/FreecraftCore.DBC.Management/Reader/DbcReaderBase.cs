using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Nito.AsyncEx;

namespace FreecraftCore
{
	public abstract class DbcReaderBase
	{
		private readonly AsyncLock SyncObj = new AsyncLock();

		/// <summary>
		/// The stream that contains the DBC data.
		/// </summary>
		protected Stream DBCStream { get; }

		/// <inheritdoc />
		protected DbcReaderBase([NotNull] Stream dbcStream)
		{
			DBCStream = dbcStream ?? throw new ArgumentNullException(nameof(dbcStream));
		}

		protected async Task ReadBytesIntoArrayFromStream(byte[] bytes)
		{
			using(await SyncObj.LockAsync())
				for(int offset = 0; offset < bytes.Length;)
				{
					offset += await DBCStream.ReadAsync(bytes, offset, bytes.Length - offset);
				}
		}

		protected Task<DBCHeader> ReadDBCHeader([NotNull] ISerializerService serializer)
		{
			if(serializer == null) throw new ArgumentNullException(nameof(serializer));

			//Read the header, it contains some information needed to read the whole DBC
			return serializer.DeserializeAsync<DBCHeader>(new DefaultStreamReaderStrategyAsync(DBCStream));
		}
	}
}
