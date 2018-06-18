using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	public interface IDbcStringReadable
	{
		/// <summary>
		/// Parses the DBC file for only the string block.
		/// </summary>
		/// <returns>The string data in the DBC file.</returns>
		Task<IReadOnlyDictionary<uint, string>> ParseOnlyStrings();
	}
}
