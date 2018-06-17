using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	/// <summary>
	/// Flattened spell visual data model.
	/// Flatten because EF does not support arrays.
	/// </summary>
	[Owned]
	[WireDataContract]
	public sealed class SpellVisualData
	{
		/// <summary>
		/// 131-132  m_spellVisualID
		/// </summary>
		//[WireMember(75)]
		//[KnownSize(2)]
		//public uint[] SpellVisual { get; }

		[WireMember(1)]
		public uint One { get; private set; }

		[WireMember(2)]
		public uint Two { get; private set; }

		/// <inheritdoc />
		public SpellVisualData(uint one, uint two)
		{
			One = one;
			Two = two;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected SpellVisualData()
		{
			
		}
	}
}
