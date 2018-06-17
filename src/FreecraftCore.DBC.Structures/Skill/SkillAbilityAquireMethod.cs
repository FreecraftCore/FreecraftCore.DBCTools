using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Dev Wiki says: 0 - learn by trainer; 1 - learn when skill is obtained; 2 - used for racial skill spells (so similar to 1)
	/// See: https://wowdev.wiki/DB/SkillLineAbility
	/// </summary>
	public enum SkillAbilityAquireMethod : uint
	{
		/// <summary>
		/// learn by trainer
		/// </summary>
		LearnFromTrainer = 0,

		/// <summary>
		/// learn when skill is obtained
		/// </summary>
		LearnWhenObtained = 1,

		/// <summary>
		/// used for racial skill spells (so similar to 1)
		/// </summary>
		LearnedAsRacial = 2
	}
}
