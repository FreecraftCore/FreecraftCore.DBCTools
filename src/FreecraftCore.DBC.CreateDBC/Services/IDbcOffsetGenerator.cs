using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public interface IDbcOffsetGenerator
	{
		/// <summary>
		/// Creates a <see cref="uint"/> offset
		/// for the provided non-null string value.
		/// </summary>
		/// <param name="value">The string to generate an offset for.</param>
		/// <returns>The offset for where the string will be.</returns>
		uint CreateOffset([NotNull] string value);

		/// <summary>
		/// Resets the database.
		/// </summary>
		void Reset();
	}
}
