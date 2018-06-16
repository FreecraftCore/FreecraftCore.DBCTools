using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	[Owned]
	[WireDataContract]
	public sealed class RequiredReagentData
	{
		/// <summary>
		/// 50-51    m_totem
		/// </summary>
		[WireMember(49)]
		[KnownSize(2)]
		public uint[] Totem { get; }

		/// <summary>
		/// 52-59    m_reagent
		/// </summary>
		[WireMember(50)]
		[KnownSize(DBCConstants.MaxReagentCount)]
		public int[] Reagent { get; }

		/// <summary>
		/// 60-67    m_reagentCount
		/// </summary>
		[WireMember(51)]
		[KnownSize(DBCConstants.MaxReagentCount)]
		public uint[] ReagentCount { get; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected RequiredReagentData()
		{
			
		}
	}
}
