using System;

namespace GladBot
{
	[Flags]
	public enum SpellAtributeEx7 : uint
	{
		SPELL_ATTR7_ALL = 0xFFFFFFFF,
		SPELL_ATTR7_NONE = 0x00000000,
		SPELL_ATTR7_UNK0 = 0x00000001, //  0 Shaman's new spells (Call of the ...), Feign Death.
		SPELL_ATTR7_IGNORE_DURATION_MODS = 0x00000002, //  1 Duration is not affected by duration modifiers
		SPELL_ATTR7_REACTIVATE_AT_RESURRECT = 0x00000004, //  2 Paladin's auras and 65607 only.
		SPELL_ATTR7_IS_CHEAT_SPELL = 0x00000008, //  3 Cannot cast if caster doesn't have UnitFlag2 & UNIT_FLAG2_ALLOW_CHEAT_SPELLS
		SPELL_ATTR7_UNK4 = 0x00000010, //  4 Only 47883 (Soulstone Resurrection) and test spell.
		SPELL_ATTR7_SUMMON_PLAYER_TOTEM = 0x00000020, //  5 Only Shaman player totems.
		SPELL_ATTR7_NO_PUSHBACK_ON_DAMAGE = 0x00000040, //  6 Does not cause spell pushback on damage
		SPELL_ATTR7_UNK7 = 0x00000080, //  7 66218 (Launch) spell.
		SPELL_ATTR7_HORDE_ONLY = 0x00000100, //  8 Teleports, mounts and other spells.
		SPELL_ATTR7_ALLIANCE_ONLY = 0x00000200, //  9 Teleports, mounts and other spells.
		SPELL_ATTR7_DISPEL_CHARGES = 0x00000400, // 10 Dispel and Spellsteal individual charges instead of whole aura.
		SPELL_ATTR7_INTERRUPT_ONLY_NONPLAYER = 0x00000800, // 11 Only non-player casts interrupt, though Feral Charge - Bear has it.
		SPELL_ATTR7_UNK12 = 0x00001000, // 12 Not set in 3.2.2a.
		SPELL_ATTR7_UNK13 = 0x00002000, // 13 Not set in 3.2.2a.
		SPELL_ATTR7_UNK14 = 0x00004000, // 14 Only 52150 (Raise Dead - Pet) spell.
		SPELL_ATTR7_UNK15 = 0x00008000, // 15 Exorcism. Usable on players? 100% crit chance on undead and demons?
		SPELL_ATTR7_CAN_RESTORE_SECONDARY_POWER = 0x00010000, // 16 These spells can replenish a powertype, which is not the current powertype
		SPELL_ATTR7_UNK17 = 0x00020000, // 17 Only 27965 (Suicide) spell.
		SPELL_ATTR7_HAS_CHARGE_EFFECT = 0x00040000, // 18 Only spells that have Charge among effects.
		SPELL_ATTR7_ZONE_TELEPORT = 0x00080000, // 19 Teleports to specific zones.
		SPELL_ATTR7_UNK20 = 0x00100000, // 20 Blink, Divine Shield, Ice Block
		SPELL_ATTR7_UNK21 = 0x00200000, // 21 Not set
		SPELL_ATTR7_UNK22 = 0x00400000, // 22
		SPELL_ATTR7_UNK23 = 0x00800000, // 23 Motivate, Mutilate, Shattering Throw
		SPELL_ATTR7_UNK24 = 0x01000000, // 24 Motivate, Mutilate, Perform Speech, Shattering Throw
		SPELL_ATTR7_UNK25 = 0x02000000, // 25
		SPELL_ATTR7_UNK26 = 0x04000000, // 26
		SPELL_ATTR7_UNK27 = 0x08000000, // 27 Not set
		SPELL_ATTR7_CONSOLIDATED_RAID_BUFF = 0x10000000, // 28 May be collapsed in raid buff frame (clientside attribute)
		SPELL_ATTR7_UNK29 = 0x20000000, // 29 only 69028, 71237
		SPELL_ATTR7_UNK30 = 0x40000000, // 30 Burning Determination, Divine Sacrifice, Earth Shield, Prayer of Mending
		SPELL_ATTR7_CLIENT_INDICATOR = 0x80000000  // 31
	};
}