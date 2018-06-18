using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	public interface IDbcEntryReader<TDBCEntryType>
		where TDBCEntryType : IDBCEntryIdentifiable
	{
		/// <summary>
		/// Parses the DBC entries into a <see cref="ParsedDBCFile{TDBCEntryType}"/>.
		/// </summary>
		/// <returns>Future for the parsed DBC file.</returns>
		Task<ParsedDBCFile<TDBCEntryType>> Parse();
	}
}
