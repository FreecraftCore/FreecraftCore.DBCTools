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
		public SpellTotemDataChunk<uint> Totem { get; private set; }

		/// <summary>
		/// 52-59    m_reagent
		/// </summary>
		[WireMember(50)]
		public ReagentDataChunk<int> ReagentId { get; private set; }

		/// <summary>
		/// 60-67    m_reagentCount
		/// </summary>
		[WireMember(51)]
		public ReagentDataChunk<uint> ReagentCount { get; private set; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected RequiredReagentData()
		{
			
		}
	}
}
