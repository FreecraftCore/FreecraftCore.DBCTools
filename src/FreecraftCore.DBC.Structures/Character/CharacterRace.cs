using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	// Race value is index in ChrRaces.dbc
	public enum CharacterRace : int
	{
		RACE_NONE = 0,
		RACE_HUMAN = 1,
		RACE_ORC = 2,
		RACE_DWARF = 3,
		RACE_NIGHTELF = 4,
		RACE_UNDEAD_PLAYER = 5,
		RACE_TAUREN = 6,
		RACE_GNOME = 7,
		RACE_TROLL = 8,
		//RACE_GOBLIN             = 9,
		RACE_BLOODELF = 10,
		RACE_DRAENEI = 11
		//RACE_FEL_ORC            = 12,
		//RACE_NAGA               = 13,
		//RACE_BROKEN             = 14,
		//RACE_SKELETON           = 15,
		//RACE_VRYKUL             = 16,
		//RACE_TUSKARR            = 17,
		//RACE_FOREST_TROLL       = 18,
		//RACE_TAUNKA             = 19,
		//RACE_NORTHREND_SKELETON = 20,
		//RACE_ICE_TROLL          = 21
	};
}
