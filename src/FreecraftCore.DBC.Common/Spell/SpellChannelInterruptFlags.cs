using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	//TODO: What does TC mean by the below comment?
	//From Trinitycore
	// See SpellAuraInterruptFlags for other values definitions
	/// <summary>
	/// Enumeration of channeling interupt flags.
	/// </summary>
	[Flags]
	public enum SpellChannelInterruptFlags : uint
	{
		CHANNEL_INTERRUPT_FLAG_INTERRUPT = 0x08,  // interrupt
		CHANNEL_FLAG_DELAY = 0x4000
	}
}
