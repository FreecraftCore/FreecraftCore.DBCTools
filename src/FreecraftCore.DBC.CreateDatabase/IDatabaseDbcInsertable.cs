using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public interface IDatabaseDbcInsertable<TDBCInsertType>
		where TDBCInsertType : IDBCEntryIdentifiable
	{
		/// <summary>
		/// Inserts the entries.
		/// Returns the amount of entries inserted.
		/// </summary>
		/// <param name="entries">The entries to insert.</param>
		/// <returns>The amount of entires inserted.</returns>
		Task<int> InsertEntriesAsync([NotNull] IReadOnlyCollection<TDBCInsertType> entries);
	}
}
