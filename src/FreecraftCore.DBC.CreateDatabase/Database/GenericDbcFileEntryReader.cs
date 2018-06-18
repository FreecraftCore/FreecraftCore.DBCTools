using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Simplfied the reading of a DBC file from a file.
	/// </summary>
	public sealed class GenericDbcFileEntryReader<TDBCEntryType> : IDbcEntryReader<TDBCEntryType>
		where TDBCEntryType : IDBCEntryIdentifiable
	{
		private string FilePath { get; }

		public GenericDbcFileEntryReader(string filePath)
		{
			FilePath = filePath;
		}

		public async Task<ParsedDBCFile<TDBCEntryType>> Parse()
		{
			using(FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
			{
				DBCEntryReader<TDBCEntryType> reader = new DBCEntryReader<TDBCEntryType>(fileStream);

				return await reader.Parse();
			}
		}
	}
}
