using System;

namespace GladBot
{
	[Flags]
	public enum SpellCastTargetFlags
	{
		TARGET_FLAG_SELF = 0x00000000,
		TARGET_FLAG_UNUSED_1 = 0x00000001,               // not used
		TARGET_FLAG_UNIT = 0x00000002,               // pguid
		TARGET_FLAG_UNIT_RAID = 0x00000004,               // not sent, used to validate target (if raid member)
		TARGET_FLAG_UNIT_PARTY = 0x00000008,               // not sent, used to validate target (if party member)
		TARGET_FLAG_ITEM = 0x00000010,               // pguid
		TARGET_FLAG_SOURCE_LOCATION = 0x00000020,               // pguid, 3 float
		TARGET_FLAG_DEST_LOCATION = 0x00000040,               // pguid, 3 float
		TARGET_FLAG_UNIT_ENEMY = 0x00000080,               // not sent, used to validate target (if enemy)
		TARGET_FLAG_UNIT_ALLY = 0x00000100,               // not sent, used to validate target (if ally)
		TARGET_FLAG_CORPSE_ENEMY = 0x00000200,               // pguid
		TARGET_FLAG_UNIT_DEAD = 0x00000400,               // not sent, used to validate target (if dead creature)
		TARGET_FLAG_GAMEOBJECT = 0x00000800,               // pguid, used with TARGET_GAMEOBJECT
		TARGET_FLAG_TRADE_ITEM = 0x00001000,               // pguid
		TARGET_FLAG_STRING = 0x00002000,               // string
		TARGET_FLAG_GAMEOBJECT_ITEM = 0x00004000,               // not sent, used with TARGET_GAMEOBJECT_ITEM
		TARGET_FLAG_CORPSE_ALLY = 0x00008000,               // pguid
		TARGET_FLAG_UNIT_MINIPET = 0x00010000,               // pguid, used to validate target (if non combat pet)
		TARGET_FLAG_GLYPH_SLOT = 0x00020000,               // used in glyph spells
		TARGET_FLAG_UNK19 = 0x00040000,               // sometimes appears with DEST_TARGET spells (may appear or not for a given spell)
		TARGET_FLAG_UNUSED20 = 0x00080000,               // uint32 counter, loop { vec3 - screen position (?), guid }, not used so far
		TARGET_FLAG_UNIT_PASSENGER = 0x00100000,               // guessed, used to validate target (if vehicle passenger)
	};
}