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
	/// type signature fill the database table.
	/// </summary>
	public interface ITableFillable
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
