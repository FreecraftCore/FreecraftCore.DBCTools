using System;

namespace FreecraftCore
{
	[Flags]
	public enum InventoryTypeMask
	{
		ALL = -1,
		NON_EQUIP = 1 << 0,
		HEAD = 1 << 1,
		NECK = 1 << 2,
		SHOULDERS = 1 << 3,
		BODY = 1 << 4,
		CHEST = 1 << 5,
		WAIST = 1 << 6,
		LEGS = 1 << 7,
		FEET = 1 << 8,
		WRISTS = 1 << 9,
		HANDS = 1 << 10,
		FINGER = 1 << 11,
		TRINKET = 1 << 12,
		WEAPON = 1 << 13,
		SHIELD = 1 << 14,
		RANGED = 1 << 15,
		CLOAK = 1 << 16,
		WEAPON_2H = 1 << 17,
		BAG = 1 << 18,
		TABARD = 1 << 19,
		ROBE = 1 << 20,
		WEAPONMAINHAND = 1 << 21,
		WEAPONOFFHAND = 1 << 22,
		HOLDABLE = 1 << 23,
		AMMO = 1 << 24,
		THROWN = 1 << 25,
		RANGEDRIGHT = 1 << 26,
		QUIVER = 1 << 27,
		RELIC = 1 << 28,
	};
}