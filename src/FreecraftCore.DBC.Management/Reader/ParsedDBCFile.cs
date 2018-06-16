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
		public IReadOnlyDictionary<uint, TDBCEntryType> RecordDatabase { get; }

		/// <summary>
		/// The string database containing all the DBC strin entries.
		/// The key should be identical to the offsets.
		/// </summary>
		public IReadOnlyDictionary<uint, string> StringDatabase { get; }

		/// <inheritdoc />
		public ParsedDBCFile([NotNull] IReadOnlyDictionary<uint, TDBCEntryType> recordDatabase, [NotNull] IReadOnlyDictionary<uint, string> stringDatabase)
		{
			RecordDatabase = recordDatabase ?? throw new ArgumentNullException(nameof(recordDatabase));
			StringDatabase = stringDatabase ?? throw new ArgumentNullException(nameof(stringDatabase));
		}
	}
}
