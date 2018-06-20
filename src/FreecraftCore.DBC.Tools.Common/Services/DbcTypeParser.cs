using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	//TODO: Support caching
	public sealed class DbcTypeParser
	{
		/// <summary>
		/// Indicates if the DBC type <see cref="dbcType"/>
		/// is a known or implemented type.
		/// </summary>
		/// <param name="dbcType">The DBC type to check for.</param>
		/// <returns></returns>
		public bool HasDbcType(string dbcType)
		{
			return ComputeDbcType(dbcType) != null;
		}

		/// <summary>
		/// Translates the provided string <see cref="dbcType"/>
		/// to the actual <see cref="Type"/>.
		/// </summary>
		/// <param name="dbcType">The string DBC name.</param>
		/// <returns>The DBC model <see cref="Type"/> or null if known exist.</returns>
		public Type ComputeDbcType([NotNull] string dbcType)
		{
			if(string.IsNullOrEmpty(dbcType)) throw new ArgumentException("Value cannot be null or empty.", nameof(dbcType));

			//We can scan for the DBC model type knowing the file name.
			return typeof(DBCHeader)
				.Assembly
				.GetExportedTypes()
				.FirstOrDefault(t => t.GetCustomAttribute<TableAttribute>()?.Name == dbcType);
		}
	}
}
