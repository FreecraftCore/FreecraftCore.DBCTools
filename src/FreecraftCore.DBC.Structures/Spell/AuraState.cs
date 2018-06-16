namespace GladBot
{
	public enum AuraState
	{   // (C) used in caster aura state     (T) used in target aura state
		// (c) used in caster aura state-not (t) used in target aura state-not
		AURA_STATE_NONE = 0,
		AURA_STATE_DEFENSE = 1,            // C   |
		AURA_STATE_HEALTHLESS_20_PERCENT = 2,            // CcT |
		AURA_STATE_BERSERKING = 3,            // C T |
		AURA_STATE_FROZEN = 4,            //  c t| frozen target
		AURA_STATE_JUDGEMENT = 5,            // C   |
		AURA_STATE_UNKNOWN6 = 6,            //     | not used
		AURA_STATE_HUNTER_PARRY = 7,            // C   |
		//AURA_STATE_ROGUE_ATTACK_FROM_STEALTH    = 7,      // C   | FIX ME: not implemented yet!
		//AURA_STATE_UNKNOWN7                     = 7,      //  c  | random/focused bursts spells (?)
		AURA_STATE_UNKNOWN8 = 8,            //     | not used
		AURA_STATE_UNKNOWN9 = 9,            //     | not used
		AURA_STATE_WARRIOR_VICTORY_RUSH = 10,           // C   | warrior victory rush
		AURA_STATE_UNKNOWN11 = 11,           //    t|
		AURA_STATE_FAERIE_FIRE = 12,           //  c t| prevent invisibility
		AURA_STATE_HEALTHLESS_35_PERCENT = 13,           // C T |
		AURA_STATE_CONFLAGRATE = 14,           //   T | per-caster
		AURA_STATE_SWIFTMEND = 15,           //   T |
		AURA_STATE_DEADLY_POISON = 16,           //   T |
		AURA_STATE_ENRAGE = 17,           // C   |
		AURA_STATE_BLEEDING = 18,           // C  t|
		AURA_STATE_UNKNOWN19 = 19,           //     | not used
		AURA_STATE_UNKNOWN20 = 20,           //  c  | only (45317 Suicide)
		AURA_STATE_UNKNOWN21 = 21,           //     | not used
		AURA_STATE_UNKNOWN22 = 22,           // C  t| not implemented yet (Requires Evasive Charges to use)
		AURA_STATE_HEALTH_ABOVE_75_PERCENT = 23            // C   |
	};
}