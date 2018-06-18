using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Simplfied the reading of a DBC strings from a file.
	/// </summary>
	public sealed class DbcFileStringReader : IDbcStringReadable
	{
		private string FilePath { get; }

		public DbcFileStringReader([NotNull] string filePath)
		{
			if(string.IsNullOrEmpty(filePath)) throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));

			FilePath = filePath;
		}

		/// <inheritdoc />
		public async Task<IReadOnlyDictionary<uint, string>> ParseOnlyStrings()
		{
			using(FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
			{
				DbcStringReader reader = new DbcStringReader(fileStream);

				return await reader.ParseOnlyStrings();
			}
		}
	}
}
