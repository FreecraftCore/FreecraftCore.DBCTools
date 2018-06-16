using System;

namespace FreecraftCore
{
	[Flags]
	public enum SpellAtributeEx : uint
	{
		SPELL_ATTR1_ALL = 0xFFFFFFFF,
		SPELL_ATTR1_NONE = 0x00000000,
		SPELL_ATTR1_DISMISS_PET = 0x00000001, //  0 for spells without this flag client doesn't allow to summon pet if caster has a pet
		SPELL_ATTR1_DRAIN_ALL_POWER = 0x00000002, //  1 use all power (Only paladin Lay of Hands and Bunyanize)
		SPELL_ATTR1_CHANNELED_1 = 0x00000004, //  2 clientside checked? cancelable?
		SPELL_ATTR1_CANT_BE_REDIRECTED = 0x00000008, //  3
		SPELL_ATTR1_UNK4 = 0x00000010, //  4 stealth and whirlwind
		SPELL_ATTR1_NOT_BREAK_STEALTH = 0x00000020, //  5 Not break stealth
		SPELL_ATTR1_CHANNELED_2 = 0x00000040, //  6
		SPELL_ATTR1_CANT_BE_REFLECTED = 0x00000080, //  7
		SPELL_ATTR1_CANT_TARGET_IN_COMBAT = 0x00000100, //  8 can target only out of combat units
		SPELL_ATTR1_MELEE_COMBAT_START = 0x00000200, //  9 player starts melee combat after this spell is cast
		SPELL_ATTR1_NO_THREAT = 0x00000400, // 10 no generates threat on cast 100% (old NO_INITIAL_AGGRO)
		SPELL_ATTR1_UNK11 = 0x00000800, // 11 aura
		SPELL_ATTR1_IS_PICKPOCKET = 0x00001000, // 12 Pickpocket
		SPELL_ATTR1_FARSIGHT = 0x00002000, // 13 Client removes farsight on aura loss
		SPELL_ATTR1_CHANNEL_TRACK_TARGET = 0x00004000, // 14 Client automatically forces player to face target when channeling
		SPELL_ATTR1_DISPEL_AURAS_ON_IMMUNITY = 0x00008000, // 15 remove auras on immunity
		SPELL_ATTR1_UNAFFECTED_BY_SCHOOL_IMMUNE = 0x00010000, // 16 on immuniy
		SPELL_ATTR1_UNAUTOCASTABLE_BY_PET = 0x00020000, // 17
		SPELL_ATTR1_UNK18 = 0x00040000, // 18 stun, polymorph, daze, hex
		SPELL_ATTR1_CANT_TARGET_SELF = 0x00080000, // 19
		SPELL_ATTR1_REQ_COMBO_POINTS1 = 0x00100000, // 20 Req combo points on target
		SPELL_ATTR1_UNK21 = 0x00200000, // 21
		SPELL_ATTR1_REQ_COMBO_POINTS2 = 0x00400000, // 22 Req combo points on target
		SPELL_ATTR1_UNK23 = 0x00800000, // 23
		SPELL_ATTR1_IS_FISHING = 0x01000000, // 24 only fishing spells
		SPELL_ATTR1_UNK25 = 0x02000000, // 25
		SPELL_ATTR1_UNK26 = 0x04000000, // 26 works correctly with [target=focus] and [target=mouseover] macros?
		SPELL_ATTR1_UNK27 = 0x08000000, // 27 melee spell?
		SPELL_ATTR1_DONT_DISPLAY_IN_AURA_BAR = 0x10000000, // 28 client doesn't display these spells in aura bar
		SPELL_ATTR1_CHANNEL_DISPLAY_SPELL_NAME = 0x20000000, // 29 spell name is displayed in cast bar instead of 'channeling' text
		SPELL_ATTR1_ENABLE_AT_DODGE = 0x40000000, // 30 Overpower
		SPELL_ATTR1_UNK31 = 0x80000000  // 31
	};
}