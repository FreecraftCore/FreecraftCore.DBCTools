using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	[WireDataContract]
	[JsonObject]
	[Table("SkillLineAbility")]
	public sealed class SkillLineAbilityEntry : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		[JsonIgnore]
		[NotMapped]
		public uint EntryId => (uint)SkillLineAbilityId;

		/// <summary>
		/// 0        m_ID
		/// </summary>
		[Key]
		[WireMember(1)]
		public int SkillLineAbilityId { get; private set; }

		/// <summary>
		/// 1        m_skillLine
		/// SkillLine.dbc
		/// </summary>
		[WireMember(2)]
		public uint SkillId { get; private set; }

		/// <summary>
		/// 2        m_spell
		/// Spell.dbc
		/// </summary>
		[WireMember(3)]
		public uint SpellId { get; private set; }

		/// <summary>
		/// 3        m_raceMask
		/// Represents a bitmask that indicates
		/// which races can use this ability.
		/// See: https://wowdev.wiki/DB/ChrRaces and TC: RACEMASK_ALL_PLAYABLE etc
		/// </summary>
		[WireMember(4)]
		public uint Racemask { get; private set; }

		/// <summary>
		/// 4        m_classMask
		/// Similar to <see cref="Racemask"/>. Is a bitmask that indicates
		/// which classes can use this ability.
		/// See: https://wowdev.wiki/DB/ChrClasses
		/// </summary>
		[WireMember(5)]
		public uint Classmask { get; private set; }

		/// <summary>
		/// 5        m_excludeRace
		/// Similar to <see cref="Racemask"/>. Just indicates which races
		/// should be excluded.
		/// </summary>
		[WireMember(6)]
		public uint RacemaskNot { get; private set; }

		/// <summary>
		/// 6        m_excludeClass
		/// Similar to <see cref="Classmask"/>. Just indicates which classes
		/// should be excluded.
		/// </summary>
		[WireMember(7)]
		public uint ClassmaskNot { get; private set; }

		/// <summary>
		/// 7        m_minSkillLineRank
		/// </summary>
		[WireMember(8)]
		public uint RequiredSkillValue { get; private set; }

		/// <summary>
		/// 8        m_supercededBySpell
		/// The spell that supersedes this one
		/// Wiki says: Spell.dbc_parent
		/// </summary>
		[WireMember(9)]
		public uint ForwardSpellid { get; private set; }

		/// <summary>
		/// 9        m_acquireMethod
		/// </summary>
		[WireMember(10)]
		public SkillAbilityAquireMethod SkillAquireMethod { get; private set; }

		//TODO: Consider renaming
		/// <summary>
		/// 10       m_trivialSkillLineRankHigh
		/// Wiki says: Skill becomes grey (green = (grey+yellow)/2)
		/// See: https://wowdev.wiki/DB/SkillLineAbility
		/// </summary>
		[WireMember(11)]
		public uint MaxValue { get; private set; }

		//TODO: Consider renaming
		/// <summary>
		/// 11       m_trivialSkillLineRankLow
		/// Wiki says: Skill becomes yellow (below is orange)
		/// See: https://wowdev.wiki/DB/SkillLineAbility
		/// </summary>
		[WireMember(12)]
		public uint MinValue { get; private set; }

		//TODO: What does this mean?
		/// <summary>
		/// 12-13    m_characterPoints[2]
		/// </summary>
		[WireMember(13)]
		public Vector2<uint> CharacterPoints { get; private set; }

		/// <inheritdoc />
		public SkillLineAbilityEntry(int skillLineAbilityId, uint skillId, uint spellId, uint racemask, uint classmask, uint racemaskNot, uint classmaskNot, uint requiredSkillValue, uint forwardSpellid, SkillAbilityAquireMethod skillAquireMethod, uint maxValue, uint minValue, Vector2<uint> characterPoints)
		{
			SkillLineAbilityId = skillLineAbilityId;
			SkillId = skillId;
			SpellId = spellId;
			Racemask = racemask;
			Classmask = classmask;
			RacemaskNot = racemaskNot;
			ClassmaskNot = classmaskNot;
			RequiredSkillValue = requiredSkillValue;
			ForwardSpellid = forwardSpellid;
			SkillAquireMethod = skillAquireMethod;
			MaxValue = maxValue;
			MinValue = minValue;
			CharacterPoints = characterPoints;
		}

		/// <summary>
		/// serializer ctor
		/// </summary>
		public SkillLineAbilityEntry()
		{
			
		}
	};
}
