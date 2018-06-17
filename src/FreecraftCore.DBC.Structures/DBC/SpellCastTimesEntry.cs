using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//Referenced in Spell.dbc as CastingTimeIndex
	[JsonObject]
	[WireDataContract]
	[Table("SpellCastTime")]
	public class SpellCastTimesEntry : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		[JsonIgnore]
		[NotMapped]
		public uint EntryId => (uint)SpellCastTimeId;

		[Key]
		[WireMember(1)]
		public int SpellCastTimeId { get; private set; }

		[WireMember(2)]
		public int CastTime { get; private set; }

		//TODO: Conflicting Spellwork/TC/WoWDevWiki information on if this is float or uint

		[WireMember(3)]
		public float CastTimePerLevel { get; private set; }

		[WireMember(4)]
		public int MinCastTime { get; private set; }

		/// <inheritdoc />
		public SpellCastTimesEntry(int spellCastTimeId, int castTime, float castTimePerLevel, int minCastTime)
		{
			if(spellCastTimeId < 0) throw new ArgumentOutOfRangeException(nameof(spellCastTimeId));

			SpellCastTimeId = spellCastTimeId;
			CastTime = castTime;
			CastTimePerLevel = castTimePerLevel;
			MinCastTime = minCastTime;
		}

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public SpellCastTimesEntry()
		{
			
		}
	}

}
