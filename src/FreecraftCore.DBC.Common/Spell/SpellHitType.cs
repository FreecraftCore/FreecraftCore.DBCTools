using System;

namespace GladBot
{
	[Flags]
	public enum SpellHitType
	{
		SPELL_HIT_TYPE_UNK1 = 0x00001,
		SPELL_HIT_TYPE_CRIT = 0x00002,
		SPELL_HIT_TYPE_UNK3 = 0x00004,
		SPELL_HIT_TYPE_UNK4 = 0x00008,
		SPELL_HIT_TYPE_UNK5 = 0x00010,                          // replace caster?
		SPELL_HIT_TYPE_UNK6 = 0x00020
	};
}