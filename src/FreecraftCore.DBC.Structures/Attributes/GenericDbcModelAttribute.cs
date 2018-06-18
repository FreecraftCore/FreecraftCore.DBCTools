using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class GenericDbcModelAttribute : Attribute
	{
		/// <summary>
		/// Indicates the closed generic type
		/// for the DBC file type.
		/// </summary>
		public Type ClosedGenericForFile { get; }

		/// <summary>
		/// Indicates the closed generic type
		/// for the DBC model in the SQL database.
		/// </summary>
		public Type ClosedGenericForDatabase { get; }

		/// <inheritdoc />
		public GenericDbcModelAttribute([NotNull] Type closedGenericForFile, [NotNull] Type closedGenericForDatabase)
		{
			ClosedGenericForFile = closedGenericForFile ?? throw new ArgumentNullException(nameof(closedGenericForFile));
			ClosedGenericForDatabase = closedGenericForDatabase ?? throw new ArgumentNullException(nameof(closedGenericForDatabase));

			//TODO: Check that they are generic.
			if(ClosedGenericForDatabase.GetGenericTypeDefinition() != ClosedGenericForFile.GetGenericTypeDefinition())
				throw new InvalidOperationException($"Invalid DBC Generic Attibute. Both Types: {closedGenericForFile.Name} and {closedGenericForDatabase.Name} must be related to same open generic Type.");
		}

		private GenericDbcModelAttribute()
		{
			
		}
	}
}
