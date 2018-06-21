using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	public interface IDbcFileGenerator<in TDbcFileType>
	{
		/// <summary>
		/// Writes the provided <see cref="entries"/>.
		/// </summary>
		/// <param name="entries">The entries.</param>
		/// <returns></returns>
		Task WriteEntries(IReadOnlyCollection<TDbcFileType> entries);
	}
}
