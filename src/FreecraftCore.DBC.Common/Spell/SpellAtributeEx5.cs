using System;

namespace FreecraftCore
{
	[Flags]
	public enum SpellAtributeEx5 : uint
	{
		SPELL_ATTR5_ALL = 0xFFFFFFFF,
		SPELL_ATTR5_NONE = 0x00000000,
		SPELL_ATTR5_CAN_CHANNEL_WHEN_MOVING = 0x00000001, //  0 available casting channel spell when moving
		SPELL_ATTR5_NO_REAGENT_WHILE_PREP = 0x00000002, //  1 not need reagents if UNIT_FLAG_PREPARATION
		SPELL_ATTR5_UNK2 = 0x00000004, //  2
		SPELL_ATTR5_USABLE_WHILE_STUNNED = 0x00000008, //  3 usable while stunned
		SPELL_ATTR5_UNK4 = 0x00000010, //  4
		SPELL_ATTR5_SINGLE_TARGET_SPELL = 0x00000020, //  5 Only one target can be apply at a time
		SPELL_ATTR5_UNK6 = 0x00000040, //  6
		SPELL_ATTR5_UNK7 = 0x00000080, //  7
		SPELL_ATTR5_UNK8 = 0x00000100, //  8
		SPELL_ATTR5_START_PERIODIC_AT_APPLY = 0x00000200, //  9 begin periodic tick at aura apply
		SPELL_ATTR5_HIDE_DURATION = 0x00000400, // 10 do not send duration to client
		SPELL_ATTR5_ALLOW_TARGET_OF_TARGET_AS_TARGET = 0x00000800, // 11 (NYI) uses target's target as target if original target not valid (intervene for example)
		SPELL_ATTR5_UNK12 = 0x00001000, // 12 Cleave related?
		SPELL_ATTR5_HASTE_AFFECT_DURATION = 0x00002000, // 13 haste effects decrease duration of this
		SPELL_ATTR5_UNK14 = 0x00004000, // 14
		SPELL_ATTR5_UNK15 = 0x00008000, // 15 Inflits on multiple targets?
		SPELL_ATTR5_SPECIAL_ITEM_CLASS_CHECK = 0x00010000, // 16 this allows spells with EquippedItemClass to affect spells from other items if the required item is equipped
		SPELL_ATTR5_USABLE_WHILE_FEARED = 0x00020000, // 17 usable while feared
		SPELL_ATTR5_USABLE_WHILE_CONFUSED = 0x00040000, // 18 usable while confused
		SPELL_ATTR5_DONT_TURN_DURING_CAST = 0x00080000, // 19 Blocks caster's turning when casting (client does not automatically turn caster's model to face UNIT_FIELD_TARGET)
		SPELL_ATTR5_UNK20 = 0x00100000, // 20
		SPELL_ATTR5_UNK21 = 0x00200000, // 21
		SPELL_ATTR5_UNK22 = 0x00400000, // 22
		SPELL_ATTR5_UNK23 = 0x00800000, // 23
		SPELL_ATTR5_UNK24 = 0x01000000, // 24
		SPELL_ATTR5_UNK25 = 0x02000000, // 25
		SPELL_ATTR5_UNK26 = 0x04000000, // 26 aoe related - Boulder, Cannon, Corpse Explosion, Fire Nova, Flames, Frost Bomb, Living Bomb, Seed of Corruption, Starfall, Thunder Clap, Volley
		SPELL_ATTR5_DONT_SHOW_AURA_IF_SELF_CAST = 0x08000000, // 27 Auras with this attribute are not visible on units that are the caster
		SPELL_ATTR5_DONT_SHOW_AURA_IF_NOT_SELF_CAST = 0x10000000, // 28 Auras with this attribute are not visible on units that are not the caster
		SPELL_ATTR5_UNK29 = 0x20000000, // 29
		SPELL_ATTR5_UNK30 = 0x40000000, // 30
		SPELL_ATTR5_UNK31 = 0x80000000  // 31 Forces all nearby enemies to focus attacks caster
	};
}