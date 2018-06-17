using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for types that are DBC entries.
	/// </summary>
	public interface IDBCEntryIdentifiable
	{
		//Should not be written to JSON or the database
		/// <summary>
		/// The entry ID for the DBC entry.
		/// </summary>
		[JsonIgnore]
		[NotMapped]
		uint EntryId { get; }
	}
}
