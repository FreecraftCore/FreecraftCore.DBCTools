using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for types that are DBC entries.
	/// </summary>
	public interface IDBCEntryIdentifiable
	{
		/// <summary>
		/// The entry ID for the DBC entry.
		/// </summary>
		uint EntryId { get; }
	}
}
