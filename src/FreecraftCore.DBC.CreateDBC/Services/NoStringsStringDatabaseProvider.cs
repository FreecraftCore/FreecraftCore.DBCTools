using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public sealed class NoStringsStringDatabaseProvider : IStringDatabaseProvider
	{
		//TODO: Should we include null or empty string?
		/// <summary>
		/// Static cached empty string database with a 0 offset.
		/// </summary>
		private static DbcStringDatabase EmptyStringDatabase { get; } = new DbcStringDatabase(new Dictionary<string, uint>(), 0);

		/// <inheritdoc />
		public DbcStringDatabase BuildDatabase()
		{
			return EmptyStringDatabase;
		}
	}
}
