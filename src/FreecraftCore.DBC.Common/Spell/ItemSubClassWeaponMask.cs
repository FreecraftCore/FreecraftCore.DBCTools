using System;

namespace GladBot
{
	[Flags]
	public enum ItemSubClassWeaponMask
	{
		ALL = -1,
		AXE = 1 << 0,
		AXE2 = 1 << 1,
		BOW = 1 << 2,
		GUN = 1 << 3,
		MACE = 1 << 4,
		MACE2 = 1 << 5,
		POLEARM = 1 << 6,
		SWORD = 1 << 7,
		SWORD2 = 1 << 8,
		OBSOLETE = 1 << 9,
		STAFF = 1 << 10,
		EXOTIC = 1 << 11,
		EXOTIC2 = 1 << 12,
		FIST = 1 << 13,
		MISC = 1 << 14,
		DAGGER = 1 << 15,
		THROWN = 1 << 16,
		SPEAR = 1 << 17,
		CROSSBOW = 1 << 18,
		WAND = 1 << 19,
		FISHING_POLE = 1 << 20
	};
}