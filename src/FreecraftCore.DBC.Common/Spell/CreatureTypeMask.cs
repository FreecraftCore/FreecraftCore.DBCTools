using System;

namespace FreecraftCore
{
	[Flags]
	public enum CreatureTypeMask
	{
		ALL = -1,
		NONE = 0,
		BEAST = 1 << 0,
		DRAGONKIN = 1 << 1,
		DEMON = 1 << 2,
		ELEMENTAL = 1 << 3,
		GIANT = 1 << 4,
		UNDEAD = 1 << 5,
		HUMANOID = 1 << 6,
		CRITTER = 1 << 7,
		MECHANICAL = 1 << 8,
		NOT_SPECIFIED = 1 << 9,
		TOTEM = 1 << 10,
		NON_COMBAT_PET = 1 << 11,
		GAS_CLOUD = 1 << 12
	};
}