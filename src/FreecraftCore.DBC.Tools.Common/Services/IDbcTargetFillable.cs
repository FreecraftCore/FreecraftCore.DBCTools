using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	/// <summary>
	/// Simple non-generic interface that exposes
	/// simple <see cref="Fill"/> methods that can be invoked
	/// to the let the underlying complex Type with an unknown
	/// type signature fill the target output type (database table or output file).
	/// </summary>
	public interface IDbcTargetFillable
	{
		/// <summary>
		/// Fills the table.
		/// </summary>
		void Fill();

		/// <summary>
		/// Asyncronously fills the table.
		/// </summary>
		/// <returns></returns>
		Task FillAsync();
	}
}
