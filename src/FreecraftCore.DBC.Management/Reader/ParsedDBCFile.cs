using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Represents a fully parsed DBC file.
	/// </summary>
	/// <typeparam name="TDBCEntryType"></typeparam>
	public sealed class ParsedDBCFile<TDBCEntryType>
		where TDBCEntryType : IDBCEntryIdentifiable
	{
		/// <summary>
		/// The record database containing all the DBC record entries.
		/// </summary>
		public IReadOnlyDictionary<int, TDBCEntryType> RecordDatabase { get; }

		/// <inheritdoc />
		public ParsedDBCFile([NotNull] IReadOnlyDictionary<int, TDBCEntryType> recordDatabase)
		{
			RecordDatabase = recordDatabase ?? throw new ArgumentNullException(nameof(recordDatabase));
		}
	}
}
