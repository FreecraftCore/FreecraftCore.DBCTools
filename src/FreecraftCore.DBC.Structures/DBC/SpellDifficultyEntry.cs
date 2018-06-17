using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//TODO: Look into how this works
	[JsonObject]
	[WireDataContract]
	[Table("SpellDifficulty")]
	public sealed class SpellDifficultyEntry : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		public uint EntryId => (uint)SpellDifficultyId;

		[Key]
		[WireMember(1)]
		public int SpellDifficultyId { get; private set; }

		//Reference to a Spell.dbc entry.
		[WireMember(2)]
		public int Normal10manSpellId { get; private set; }

		//Reference to a Spell.dbc entry.
		[WireMember(3)]
		public int Normal25manSpellId { get; private set; }

		//Reference to a Spell.dbc entry.
		[WireMember(4)]
		public int Heroic10manSpellId { get; private set; }

		//Reference to a Spell.dbc entry.
		[WireMember(5)]
		public int Heroic25manSpellId { get; private set; }

		/// <inheritdoc />
		public SpellDifficultyEntry(int spellDifficultyId, int normal10ManSpellId, int normal25ManSpellId, int heroic10ManSpellId, int heroic25ManSpellId)
		{
			if(spellDifficultyId < 0) throw new ArgumentOutOfRangeException(nameof(spellDifficultyId));

			SpellDifficultyId = spellDifficultyId;
			Normal10manSpellId = normal10ManSpellId;
			Normal25manSpellId = normal25ManSpellId;
			Heroic10manSpellId = heroic10ManSpellId;
			Heroic25manSpellId = heroic25ManSpellId;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public SpellDifficultyEntry()
		{
			
		}
	}

}
