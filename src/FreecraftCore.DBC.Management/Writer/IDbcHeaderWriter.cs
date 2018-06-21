using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	public interface IDbcHeaderWriter
	{
		/// <summary>
		/// Writes the provided <see cref="DBCHeader"/>.
		/// WARNING: This will write to position 0 in the stream for <see cref="DBCHeader.HeaderSize"/> amount.
		/// </summary>
		/// <param name="header">The header to write.</param>
		/// <returns></returns>
		Task WriteHeader(DBCHeader header);
	}
}
