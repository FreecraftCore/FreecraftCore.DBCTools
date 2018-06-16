using System;

namespace FreecraftCore
{
	[Flags]
	public enum SpellAtributeEx6 : uint
	{
		SPELL_ATTR6_ALL = 0xFFFFFFFF,
		SPELL_ATTR6_NONE = 0x00000000,
		SPELL_ATTR6_DONT_DISPLAY_COOLDOWN = 0x00000001, //  0 client doesn't display cooldown in tooltip for these spells
		SPELL_ATTR6_ONLY_IN_ARENA = 0x00000002, //  1 only usable in arena
		SPELL_ATTR6_IGNORE_CASTER_AURAS = 0x00000004, //  2
		SPELL_ATTR6_ASSIST_IGNORE_IMMUNE_FLAG = 0x00000008, //  3 skips checking UNIT_FLAG_IMMUNE_TO_PC and UNIT_FLAG_IMMUNE_TO_NPC flags on assist
		SPELL_ATTR6_UNK4 = 0x00000010, //  4
		SPELL_ATTR6_UNK5 = 0x00000020, //  5
		SPELL_ATTR6_USE_SPELL_CAST_EVENT = 0x00000040, //  6 Auras with this attribute trigger SPELL_CAST combat log event instead of SPELL_AURA_START (clientside attribute)
		SPELL_ATTR6_UNK7 = 0x00000080, //  7
		SPELL_ATTR6_CANT_TARGET_CROWD_CONTROLLED = 0x00000100, //  8
		SPELL_ATTR6_UNK9 = 0x00000200, //  9
		SPELL_ATTR6_CAN_TARGET_POSSESSED_FRIENDS = 0x00000400, // 10 NYI!
		SPELL_ATTR6_NOT_IN_RAID_INSTANCE = 0x00000800, // 11 not usable in raid instance
		SPELL_ATTR6_CASTABLE_WHILE_ON_VEHICLE = 0x00001000, // 12 castable while caster is on vehicle
		SPELL_ATTR6_CAN_TARGET_INVISIBLE = 0x00002000, // 13 ignore visibility requirement for spell target (phases, invisibility, etc.)
		SPELL_ATTR6_UNK14 = 0x00004000, // 14
		SPELL_ATTR6_UNK15 = 0x00008000, // 15 only 54368, 67892
		SPELL_ATTR6_UNK16 = 0x00010000, // 16
		SPELL_ATTR6_UNK17 = 0x00020000, // 17 Mount spell
		SPELL_ATTR6_CAST_BY_CHARMER = 0x00040000, // 18 client won't allow to cast these spells when unit is not possessed && charmer of caster will be original caster
		SPELL_ATTR6_UNK19 = 0x00080000, // 19 only 47488, 50782
		SPELL_ATTR6_ONLY_VISIBLE_TO_CASTER = 0x00100000, // 20 Auras with this attribute are only visible to their caster (or pet's owner)
		SPELL_ATTR6_CLIENT_UI_TARGET_EFFECTS = 0x00200000, // 21 it's only client-side attribute
		SPELL_ATTR6_UNK22 = 0x00400000, // 22 only 72054
		SPELL_ATTR6_UNK23 = 0x00800000, // 23
		SPELL_ATTR6_CAN_TARGET_UNTARGETABLE = 0x01000000, // 24
		SPELL_ATTR6_UNK25 = 0x02000000, // 25 Exorcism, Flash of Light
		SPELL_ATTR6_UNK26 = 0x04000000, // 26 related to player castable positive buff
		SPELL_ATTR6_UNK27 = 0x08000000, // 27
		SPELL_ATTR6_UNK28 = 0x10000000, // 28 Death Grip
		SPELL_ATTR6_NO_DONE_PCT_DAMAGE_MODS = 0x20000000, // 29 ignores done percent damage mods?
		SPELL_ATTR6_UNK30 = 0x40000000, // 30
		SPELL_ATTR6_IGNORE_CATEGORY_COOLDOWN_MODS = 0x80000000  // 31 Spells with this attribute skip applying modifiers to category cooldowns
	};
}