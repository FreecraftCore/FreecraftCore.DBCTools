using System;

namespace FreecraftCore
{
	[Flags]
	public enum SpellAtributeEx3 : uint
	{
		SPELL_ATTR3_ALL = 0xFFFFFFFF,
		SPELL_ATTR3_NONE = 0x00000000,
		SPELL_ATTR3_UNK0 = 0x00000001, //  0
		SPELL_ATTR3_UNK1 = 0x00000002, //  1
		SPELL_ATTR3_UNK2 = 0x00000004, //  2
		SPELL_ATTR3_BLOCKABLE_SPELL = 0x00000008, //  3 Only dmg class melee in 3.1.3
		SPELL_ATTR3_IGNORE_RESURRECTION_TIMER = 0x00000010, //  4 you don't have to wait to be resurrected with these spells
		SPELL_ATTR3_UNK5 = 0x00000020, //  5
		SPELL_ATTR3_UNK6 = 0x00000040, //  6
		SPELL_ATTR3_STACK_FOR_DIFF_CASTERS = 0x00000080, //  7 separate stack for every caster
		SPELL_ATTR3_ONLY_TARGET_PLAYERS = 0x00000100, //  8 can only target players
		SPELL_ATTR3_TRIGGERED_CAN_TRIGGER_PROC_2 = 0x00000200, //  9 triggered from effect?
		SPELL_ATTR3_MAIN_HAND = 0x00000400, // 10 Main hand weapon required
		SPELL_ATTR3_BATTLEGROUND = 0x00000800, // 11 Can casted only on battleground
		SPELL_ATTR3_ONLY_TARGET_GHOSTS = 0x00001000, // 12
		SPELL_ATTR3_DONT_DISPLAY_CHANNEL_BAR = 0x00002000, // 13 Clientside attribute - will not display channeling bar
		SPELL_ATTR3_IS_HONORLESS_TARGET = 0x00004000, // 14 "Honorless Target" only this spells have this flag
		SPELL_ATTR3_UNK15 = 0x00008000, // 15 Auto Shoot, Shoot, Throw,  - this is autoshot flag
		SPELL_ATTR3_CANT_TRIGGER_PROC = 0x00010000, // 16 confirmed with many patchnotes
		SPELL_ATTR3_NO_INITIAL_AGGRO = 0x00020000, // 17 Soothe Animal, 39758, Mind Soothe
		SPELL_ATTR3_IGNORE_HIT_RESULT = 0x00040000, // 18 Spell should always hit its target
		SPELL_ATTR3_DISABLE_PROC = 0x00080000, // 19 during aura proc no spells can trigger (20178, 20375)
		SPELL_ATTR3_DEATH_PERSISTENT = 0x00100000, // 20 Death persistent spells
		SPELL_ATTR3_UNK21 = 0x00200000, // 21 unused
		SPELL_ATTR3_REQ_WAND = 0x00400000, // 22 Req wand
		SPELL_ATTR3_UNK23 = 0x00800000, // 23
		SPELL_ATTR3_REQ_OFFHAND = 0x01000000, // 24 Req offhand weapon
		SPELL_ATTR3_UNK25 = 0x02000000, // 25 no cause spell pushback ?
		SPELL_ATTR3_CAN_PROC_WITH_TRIGGERED = 0x04000000, // 26 auras with this attribute can proc from triggered spell casts with SPELL_ATTR3_TRIGGERED_CAN_TRIGGER_PROC_2 (67736 + 52999)
		SPELL_ATTR3_DRAIN_SOUL = 0x08000000, // 27 only drain soul has this flag
		SPELL_ATTR3_UNK28 = 0x10000000, // 28
		SPELL_ATTR3_NO_DONE_BONUS = 0x20000000, // 29 Ignore caster spellpower and done damage mods?  client doesn't apply spellmods for those spells
		SPELL_ATTR3_DONT_DISPLAY_RANGE = 0x40000000, // 30 client doesn't display range in tooltip for those spells
		SPELL_ATTR3_UNK31 = 0x80000000  // 31
	};
}