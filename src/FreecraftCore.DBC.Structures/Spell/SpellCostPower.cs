namespace GladBot
{
	public enum SpellCostPower : uint
	{
		POWER_MANA = 0,
		POWER_RAGE = 1,
		POWER_FOCUS = 2,
		POWER_ENERGY = 3,
		POWER_HAPPINESS = 4,
		POWER_RUNE = 5,
		POWER_RUNIC_POWER = 6,
		POWER_HEALTH = 0xFFFFFFFE,    // (-2 as signed value)
	};
}