namespace GladBot
{
	/// <summary>
	/// Enumeration of the class/family a spell is associated with.
	/// </summary>
	public enum SpellFamilyName
	{
		SPELLFAMILY_GENERIC = 0,
		SPELLFAMILY_UNK1 = 1, // events, holidays
		// unused               = 2,
		SPELLFAMILY_MAGE = 3,
		SPELLFAMILY_WARRIOR = 4,
		SPELLFAMILY_WARLOCK = 5,
		SPELLFAMILY_PRIEST = 6,
		SPELLFAMILY_DRUID = 7,
		SPELLFAMILY_ROGUE = 8,
		SPELLFAMILY_HUNTER = 9,
		SPELLFAMILY_PALADIN = 10,
		SPELLFAMILY_SHAMAN = 11,
		SPELLFAMILY_UNK2 = 12, // 2 spells (silence resistance)
		SPELLFAMILY_POTION = 13,
		// unused               = 14,
		SPELLFAMILY_DEATHKNIGHT = 15,
		// unused               = 16,
		SPELLFAMILY_PET = 17
	};
}