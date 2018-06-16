using System;

namespace GladBot
{
	[Flags]
	public enum SpellAtributeEx4 : uint
	{
		SPELL_ATTR4_ALL = 0xFFFFFFFF,
		SPELL_ATTR4_NONE = 0x00000000,
		SPELL_ATTR4_IGNORE_RESISTANCES = 0x00000001, //  0 spells with this attribute will completely ignore the target's resistance (these spells can't be resisted)
		SPELL_ATTR4_PROC_ONLY_ON_CASTER = 0x00000002, //  1 proc only on effects with TARGET_UNIT_CASTER?
		SPELL_ATTR4_UNK2 = 0x00000004, //  2
		SPELL_ATTR4_UNK3 = 0x00000008, //  3
		SPELL_ATTR4_UNK4 = 0x00000010, //  4 This will no longer cause guards to attack on use??
		SPELL_ATTR4_UNK5 = 0x00000020, //  5
		SPELL_ATTR4_NOT_STEALABLE = 0x00000040, //  6 although such auras might be dispellable, they cannot be stolen
		SPELL_ATTR4_CAN_CAST_WHILE_CASTING = 0x00000080, //  7 spells forced to be triggered
		SPELL_ATTR4_FIXED_DAMAGE = 0x00000100, //  8 ignores taken percent damage mods?
		SPELL_ATTR4_TRIGGER_ACTIVATE = 0x00000200, //  9 initially disabled / trigger activate from event (Execute, Riposte, Deep Freeze end other)
		SPELL_ATTR4_SPELL_VS_EXTEND_COST = 0x00000400, // 10 Rogue Shiv have this flag
		SPELL_ATTR4_UNK11 = 0x00000800, // 11
		SPELL_ATTR4_UNK12 = 0x00001000, // 12
		SPELL_ATTR4_UNK13 = 0x00002000, // 13
		SPELL_ATTR4_DAMAGE_DOESNT_BREAK_AURAS = 0x00004000, // 14 doesn't break auras by damage from these spells
		SPELL_ATTR4_UNK15 = 0x00008000, // 15
		SPELL_ATTR4_NOT_USABLE_IN_ARENA = 0x00010000, // 16
		SPELL_ATTR4_USABLE_IN_ARENA = 0x00020000, // 17
		SPELL_ATTR4_AREA_TARGET_CHAIN = 0x00040000, // 18 (NYI)hits area targets one after another instead of all at once
		SPELL_ATTR4_UNK19 = 0x00080000, // 19 proc dalayed, after damage or don't proc on absorb?
		SPELL_ATTR4_NOT_CHECK_SELFCAST_POWER = 0x00100000, // 20 supersedes message "More powerful spell applied" for self casts.
		SPELL_ATTR4_UNK21 = 0x00200000, // 21 Pally aura, dk presence, dudu form, warrior stance, shadowform, hunter track
		SPELL_ATTR4_UNK22 = 0x00400000, // 22 Seal of Command (42058, 57770) and Gymer's Smash 55426
		SPELL_ATTR4_UNK23 = 0x00800000, // 23
		SPELL_ATTR4_UNK24 = 0x01000000, // 24 some shoot spell
		SPELL_ATTR4_IS_PET_SCALING = 0x02000000, // 25 pet scaling auras
		SPELL_ATTR4_CAST_ONLY_IN_OUTLAND = 0x04000000, // 26 Can only be used in Outland.
		SPELL_ATTR4_UNK27 = 0x08000000, // 27
		SPELL_ATTR4_UNK28 = 0x10000000, // 28 Aimed Shot
		SPELL_ATTR4_UNK29 = 0x20000000, // 29
		SPELL_ATTR4_UNK30 = 0x40000000, // 30
		SPELL_ATTR4_UNK31 = 0x80000000  // 31 Polymorph (chicken) 228 and Sonic Boom (38052, 38488)
	};
}