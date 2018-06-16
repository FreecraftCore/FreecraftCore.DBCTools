using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	//From: https://wowdev.wiki/Spell.dbc/InterruptFlags
	/// <summary>
	/// Enumeration of all spell interuption flags.
	/// </summary>
	[Flags]
	public enum SpellInteruptFlags : uint
	{
		ON_MOVEMENT = 0x01,
		PUSHBACK = 0x02,
		ON_INTERUPT_CAST = 0x04,
		ON_INTERUPT_SCHOOL = 0x08,
		ON_DAMAGE_TAKEN = 0x10,
		ON_INTERUPT_ALL = 0x20
	}
}
