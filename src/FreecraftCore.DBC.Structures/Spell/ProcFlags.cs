using System;

namespace GladBot
{
	///<summary>
	/// Spell proc event related declarations (accessed using SpellMgr functions)
	///</summary>
	[Flags]
	public enum ProcFlags
	{
		PROC_FLAG_KILLED = 0x00000001,    // 00 Killed by agressor - not sure about this flag
		PROC_FLAG_KILL = 0x00000002,    // 01 Kill target (in most cases need XP/Honor reward)

		PROC_FLAG_DONE_MELEE_AUTO_ATTACK = 0x00000004,    // 02 Done melee auto attack
		PROC_FLAG_TAKEN_MELEE_AUTO_ATTACK = 0x00000008,    // 03 Taken melee auto attack

		PROC_FLAG_DONE_SPELL_MELEE_DMG_CLASS = 0x00000010,    // 04 Done attack by Spell that has dmg class melee
		PROC_FLAG_TAKEN_SPELL_MELEE_DMG_CLASS = 0x00000020,    // 05 Taken attack by Spell that has dmg class melee

		PROC_FLAG_DONE_RANGED_AUTO_ATTACK = 0x00000040,    // 06 Done ranged auto attack
		PROC_FLAG_TAKEN_RANGED_AUTO_ATTACK = 0x00000080,    // 07 Taken ranged auto attack

		PROC_FLAG_DONE_SPELL_RANGED_DMG_CLASS = 0x00000100,    // 08 Done attack by Spell that has dmg class ranged
		PROC_FLAG_TAKEN_SPELL_RANGED_DMG_CLASS = 0x00000200,    // 09 Taken attack by Spell that has dmg class ranged

		PROC_FLAG_DONE_SPELL_NONE_DMG_CLASS_POS = 0x00000400,    // 10 Done positive spell that has dmg class none
		PROC_FLAG_TAKEN_SPELL_NONE_DMG_CLASS_POS = 0x00000800,    // 11 Taken positive spell that has dmg class none

		PROC_FLAG_DONE_SPELL_NONE_DMG_CLASS_NEG = 0x00001000,    // 12 Done negative spell that has dmg class none
		PROC_FLAG_TAKEN_SPELL_NONE_DMG_CLASS_NEG = 0x00002000,    // 13 Taken negative spell that has dmg class none

		PROC_FLAG_DONE_SPELL_MAGIC_DMG_CLASS_POS = 0x00004000,    // 14 Done positive spell that has dmg class magic
		PROC_FLAG_TAKEN_SPELL_MAGIC_DMG_CLASS_POS = 0x00008000,    // 15 Taken positive spell that has dmg class magic

		PROC_FLAG_DONE_SPELL_MAGIC_DMG_CLASS_NEG = 0x00010000,    // 16 Done negative spell that has dmg class magic
		PROC_FLAG_TAKEN_SPELL_MAGIC_DMG_CLASS_NEG = 0x00020000,    // 17 Taken negative spell that has dmg class magic

		PROC_FLAG_DONE_PERIODIC = 0x00040000,    // 18 Successful do periodic (damage / healing)
		PROC_FLAG_TAKEN_PERIODIC = 0x00080000,    // 19 Taken spell periodic (damage / healing)

		PROC_FLAG_TAKEN_DAMAGE = 0x00100000,    // 20 Taken any damage
		PROC_FLAG_DONE_TRAP_ACTIVATION = 0x00200000,    // 21 On trap activation (possibly needs name change to ON_GAMEOBJECT_CAST or USE)

		PROC_FLAG_DONE_MAINHAND_ATTACK = 0x00400000,    // 22 Done main-hand melee attacks (spell and autoattack)
		PROC_FLAG_DONE_OFFHAND_ATTACK = 0x00800000,    // 23 Done off-hand melee attacks (spell and autoattack)

		PROC_FLAG_DEATH = 0x01000000     // 24 Died in any way
	};
}