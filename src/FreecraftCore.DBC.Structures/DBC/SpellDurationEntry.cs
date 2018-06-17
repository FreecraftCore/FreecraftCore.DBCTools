using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//Referenced by Spell.dbc
	[Table("SpellDuration")]
	[JsonObject]
	[WireDataContract]
	public sealed class SpellDurationEntry : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		[JsonIgnore]
		[NotMapped]
		public uint EntryId => (uint)SpellDurationId;

		[Key]
		[WireMember(1)]
		public int SpellDurationId { get; private set; }

		[WireMember(2)]
		public uint Duration { get; private set; }

		/// <summary>
		/// Amount of milliseconds added per spell level
		/// </summary>
		[WireMember(3)]
		public uint DurationPerLevel { get; private set; }

		/// <summary>
		/// Absolute maximum spell duration
		/// </summary>
		[WireMember(4)]
		public uint MaxDuration { get; private set; }

		/// <inheritdoc />
		public SpellDurationEntry(int spellDurationId, uint duration, uint durationPerLevel, uint maxDuration)
		{
			if(spellDurationId < 0) throw new ArgumentOutOfRangeException(nameof(spellDurationId));

			SpellDurationId = spellDurationId;
			Duration = duration;
			DurationPerLevel = durationPerLevel;
			MaxDuration = maxDuration;
		}

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public SpellDurationEntry()
		{
			
		}
	}
}
