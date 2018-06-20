using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	public interface IDbcStringWriter
	{
		/// <summary>
		/// Writes the string data of <see cref="stringsToWrite"/>.
		/// </summary>
		/// <param name="stringsToWrite">The strings that should be written.</param>
		Task WriteStringContents(IReadOnlyCollection<string> stringsToWrite);
	}
}
