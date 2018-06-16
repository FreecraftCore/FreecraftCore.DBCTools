using System;

namespace FreecraftCore
{
	[Flags]
	public enum ItemSubClassArmorMask
	{
		ALL = -1,
		MISC = 1 << 0,
		CLOTH = 1 << 1,
		LEATHER = 1 << 2,
		MAIL = 1 << 3,
		PLATE = 1 << 4,
		BUCKLER = 1 << 5,
		SHIELD = 1 << 6,
		LIBRAM = 1 << 7,
		IDOL = 1 << 8,
		TOTEM = 1 << 9,
		SIGIL = 1 << 10
	};
}