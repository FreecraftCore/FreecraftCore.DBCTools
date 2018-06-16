using System;

namespace GladBot
{
	[Flags]
	public enum SpellAtributeEx2 : uint
	{
		SPELL_ATTR2_ALL = 0xFFFFFFFF,
		SPELL_ATTR2_NONE = 0x00000000,
		SPELL_ATTR2_CAN_TARGET_DEAD = 0x00000001, //  0 can target dead unit or corpse
		SPELL_ATTR2_UNK1 = 0x00000002, //  1 vanish, shadowform, Ghost Wolf and other
		SPELL_ATTR2_CAN_TARGET_NOT_IN_LOS = 0x00000004, //  2 26368 4.0.1 dbc change
		SPELL_ATTR2_UNK3 = 0x00000008, //  3
		SPELL_ATTR2_DISPLAY_IN_STANCE_BAR = 0x00000010, //  4 client displays icon in stance bar when learned, even if not shapeshift
		SPELL_ATTR2_AUTOREPEAT_FLAG = 0x00000020, //  5
		SPELL_ATTR2_CANT_TARGET_TAPPED = 0x00000040, //  6 target must be tapped by caster
		SPELL_ATTR2_UNK7 = 0x00000080, //  7
		SPELL_ATTR2_UNK8 = 0x00000100, //  8 not set in 3.0.3
		SPELL_ATTR2_UNK9 = 0x00000200, //  9
		SPELL_ATTR2_UNK10 = 0x00000400, // 10 related to tame
		SPELL_ATTR2_HEALTH_FUNNEL = 0x00000800, // 11
		SPELL_ATTR2_UNK12 = 0x00001000, // 12 Cleave, Heart Strike, Maul, Sunder Armor, Swipe
		SPELL_ATTR2_PRESERVE_ENCHANT_IN_ARENA = 0x00002000, // 13 Items enchanted by spells with this flag preserve the enchant to arenas
		SPELL_ATTR2_UNK14 = 0x00004000, // 14
		SPELL_ATTR2_UNK15 = 0x00008000, // 15 not set in 3.0.3
		SPELL_ATTR2_TAME_BEAST = 0x00010000, // 16
		SPELL_ATTR2_NOT_RESET_AUTO_ACTIONS = 0x00020000, // 17 don't reset timers for melee autoattacks (swings) or ranged autoattacks (autoshoots)
		SPELL_ATTR2_REQ_DEAD_PET = 0x00040000, // 18 Only Revive pet and Heart of the Pheonix
		SPELL_ATTR2_NOT_NEED_SHAPESHIFT = 0x00080000, // 19 does not necessarly need shapeshift
		SPELL_ATTR2_UNK20 = 0x00100000, // 20
		SPELL_ATTR2_DAMAGE_REDUCED_SHIELD = 0x00200000, // 21 for ice blocks, pala immunity buffs, priest absorb shields, but used also for other spells -> not sure!
		SPELL_ATTR2_UNK22 = 0x00400000, // 22 Ambush, Backstab, Cheap Shot, Death Grip, Garrote, Judgements, Mutilate, Pounce, Ravage, Shiv, Shred
		SPELL_ATTR2_IS_ARCANE_CONCENTRATION = 0x00800000, // 23 Only mage Arcane Concentration have this flag
		SPELL_ATTR2_UNK24 = 0x01000000, // 24
		SPELL_ATTR2_UNK25 = 0x02000000, // 25
		SPELL_ATTR2_UNK26 = 0x04000000, // 26 unaffected by school immunity
		SPELL_ATTR2_UNK27 = 0x08000000, // 27
		SPELL_ATTR2_UNK28 = 0x10000000, // 28
		SPELL_ATTR2_CANT_CRIT = 0x20000000, // 29 Spell can't crit
		SPELL_ATTR2_TRIGGERED_CAN_TRIGGER_PROC = 0x40000000, // 30 spell can trigger even if triggered
		SPELL_ATTR2_FOOD_BUFF = 0x80000000  // 31 Food or Drink Buff (like Well Fed)
	};
}