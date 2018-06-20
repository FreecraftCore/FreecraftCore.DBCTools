using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for objects that can write entries.
	/// </summary>
	/// <typeparam name="TDBCEntryType"></typeparam>
	public interface IDbcEntryWriter<in TDBCEntryType>
	{
		/// <summary>
		/// Writes the provided <see cref="entries"/>.
		/// Returns the entry size of the serialized entries.
		/// Does NOT write the header.
		/// </summary>
		/// <param name="entries">The entries to write.</param>
		/// <returns>The entry size. (size * <see cref="entries"/> = the total size written)</returns>
		Task<int> WriteContents([NotNull] IReadOnlyCollection<TDBCEntryType> entries);
	}
}
