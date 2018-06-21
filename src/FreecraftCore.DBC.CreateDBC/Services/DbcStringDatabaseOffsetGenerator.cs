using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Simple object that allows for pushes strings into a dictionary
	/// while generating their offset.
	/// </summary>
	public sealed class DbcStringDatabaseOffsetGenerator : IStringDatabaseProvider, IDbcOffsetGenerator
	{
		/// <summary>
		/// The current string offset for the DBC.
		/// </summary>
		public uint Currentoffset { get; private set; } = 0;

		//It should be noted that WoW DBCs always have an empty/null string at the begining
		//of the string block.
		//This means there should be a key that is at offset 0 that is null/empty
		//But maybe this is not the case on tables that always have non-empty string values
		//so this should be verified. But it actually won't affect anything if that is the case
		//But should be noted when you create a DBC file.
		private Dictionary<string, uint> _StringToOffsetMap { get; } = new Dictionary<string, uint>(1000);

		/// <summary>
		/// Represents the dictionary that contains all known strings
		/// and their offset as the value.
		/// The reason the offset is not the key is because this was a good way to track
		/// the existence of strings so we do not include duplicate entries for performance and memory reasons.
		/// </summary>
		public IReadOnlyDictionary<string, uint> StringToOffsetMap => _StringToOffsetMap;

		public DbcStringDatabaseOffsetGenerator()
		{
			//This pulls a null/empty string at the front of string block
			CreateOffset("");
		}

		/// <inheritdoc />
		public uint CreateOffset([NotNull] string value)
		{
			if(value == null) throw new ArgumentNullException(nameof(value));

			if(_StringToOffsetMap.ContainsKey(value))
				return _StringToOffsetMap[value];

			//Return current offset if we encounter string we didn't know.
			uint startOffset = Currentoffset;

			//Add +1 because WoW expects null terminator
			Currentoffset += (uint)(value.Length + 1);
			_StringToOffsetMap.Add(value, startOffset);

			return startOffset;
		}

		/// <summary>
		/// Builds the <see cref="DbcStringDatabase"/> from the provided
		/// data.
		/// </summary>
		/// <returns>The string database.</returns>
		public DbcStringDatabase BuildDatabase()
		{
			return new DbcStringDatabase(_StringToOffsetMap, Currentoffset);
		}
	}
}
