using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public sealed class DbcStringDatabase
	{
		//It should be noted that WoW DBCs always have an empty/null string at the begining
		//of the string block.
		//This means there should be a key that is at offset 0 that is null/empty
		//But maybe this is not the case on tables that always have non-empty string values
		//so this should be verified. But it actually won't affect anything if that is the case
		//But should be noted when you create a DBC file.
		private Dictionary<string, uint> _StringToOffsetMap { get; }

		/// <summary>
		/// Represents the dictionary that contains all known strings
		/// and their offset as the value.
		/// The reason the offset is not the key is because this was a good way to track
		/// the existence of strings so we do not include duplicate entries for performance and memory reasons.
		/// </summary>
		public IReadOnlyDictionary<string, uint> StringToOffsetMap => _StringToOffsetMap;

		/// <summary>
		/// The current string offset for the DBC.
		/// </summary>
		public uint Currentoffset { get; }

		/// <inheritdoc />
		public DbcStringDatabase(Dictionary<string, uint> stringToOffsetMap, uint currentoffset)
		{
			_StringToOffsetMap = stringToOffsetMap;
			Currentoffset = currentoffset;
		}
	}
}
