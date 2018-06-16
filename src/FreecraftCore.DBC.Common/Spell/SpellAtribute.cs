using System;

namespace GladBot
{
	[Flags]
	public enum SpellAtribute : uint
	{
		SPELL_ATTR0_ALL = 0xFFFFFFFF,
		SPELL_ATTR0_NONE = 0x00000000,
		SPELL_ATTR0_UNK0 = 0x00000001, //  0
		SPELL_ATTR0_REQ_AMMO = 0x00000002, //  1 on next ranged
		SPELL_ATTR0_ON_NEXT_SWING = 0x00000004, //  2
		SPELL_ATTR0_IS_REPLENISHMENT = 0x00000008, //  3 not set in 3.0.3
		SPELL_ATTR0_ABILITY = 0x00000010, //  4 client puts 'ability' instead of 'spell' in game strings for these spells
		SPELL_ATTR0_TRADESPELL = 0x00000020, //  5 trade spells (recipes), will be added by client to a sublist of profession spell
		SPELL_ATTR0_PASSIVE = 0x00000040, //  6 Passive spell
		SPELL_ATTR0_HIDDEN_CLIENTSIDE = 0x00000080, //  7 Spells with this attribute are not visible in spellbook or aura bar
		SPELL_ATTR0_HIDE_IN_COMBAT_LOG = 0x00000100, //  8 This attribite controls whether spell appears in combat logs
		SPELL_ATTR0_TARGET_MAINHAND_ITEM = 0x00000200, //  9 Client automatically selects item from mainhand slot as a cast target
		SPELL_ATTR0_ON_NEXT_SWING_2 = 0x00000400, // 10
		SPELL_ATTR0_UNK11 = 0x00000800, // 11
		SPELL_ATTR0_DAYTIME_ONLY = 0x00001000, // 12 only useable at daytime, not set in 2.4.2
		SPELL_ATTR0_NIGHT_ONLY = 0x00002000, // 13 only useable at night, not set in 2.4.2
		SPELL_ATTR0_INDOORS_ONLY = 0x00004000, // 14 only useable indoors, not set in 2.4.2
		SPELL_ATTR0_OUTDOORS_ONLY = 0x00008000, // 15 Only useable outdoors.
		SPELL_ATTR0_NOT_SHAPESHIFT = 0x00010000, // 16 Not while shapeshifted
		SPELL_ATTR0_ONLY_STEALTHED = 0x00020000, // 17 Must be in stealth
		SPELL_ATTR0_DONT_AFFECT_SHEATH_STATE = 0x00040000, // 18 client won't hide unit weapons in sheath on cast/channel
		SPELL_ATTR0_LEVEL_DAMAGE_CALCULATION = 0x00080000, // 19 spelldamage depends on caster level
		SPELL_ATTR0_STOP_ATTACK_TARGET = 0x00100000, // 20 Stop attack after use this spell (and not begin attack if use)
		SPELL_ATTR0_IMPOSSIBLE_DODGE_PARRY_BLOCK = 0x00200000, // 21 Cannot be dodged/parried/blocked
		SPELL_ATTR0_CAST_TRACK_TARGET = 0x00400000, // 22 Client automatically forces player to face target when casting
		SPELL_ATTR0_CASTABLE_WHILE_DEAD = 0x00800000, // 23 castable while dead?
		SPELL_ATTR0_CASTABLE_WHILE_MOUNTED = 0x01000000, // 24 castable while mounted
		SPELL_ATTR0_DISABLED_WHILE_ACTIVE = 0x02000000, // 25 Activate and start cooldown after aura fade or remove summoned creature or go
		SPELL_ATTR0_NEGATIVE_1 = 0x04000000, // 26 Many negative spells have this attr
		SPELL_ATTR0_CASTABLE_WHILE_SITTING = 0x08000000, // 27 castable while sitting
		SPELL_ATTR0_CANT_USED_IN_COMBAT = 0x10000000, // 28 Cannot be used in combat
		SPELL_ATTR0_UNAFFECTED_BY_INVULNERABILITY = 0x20000000, // 29 unaffected by invulnerability (hmm possible not...)
		SPELL_ATTR0_HEARTBEAT_RESIST_CHECK = 0x40000000, // 30 random chance the effect will end TODO: implement core support
		SPELL_ATTR0_CANT_CANCEL = 0x80000000  // 31 positive aura can't be canceled
	};
}