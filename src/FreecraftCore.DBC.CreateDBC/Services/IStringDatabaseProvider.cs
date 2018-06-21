using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public interface IStringDatabaseProvider
	{
		/// <summary>
		/// Builds the string database.
		/// </summary>
		/// <returns>The string database.</returns>
		DbcStringDatabase BuildDatabase();
	}
}
