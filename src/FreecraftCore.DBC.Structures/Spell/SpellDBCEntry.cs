﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreecraftCore
{
	/// <summary>
	/// The structure for the Spell DBC entry.
	/// </summary>
	[Table("Spell")]
	[JsonObject]
	[WireDataContract]
	public sealed class SpellDBCEntry<TStringType> : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		public uint EntryId => SpellId;

		/// <summary>
		/// 0 m_ID
		/// </summary>
		[Key]
		[WireMember(1)]
		public uint SpellId { get; }

		/// <summary>
		/// 1 m_category
		/// </summary>
		[WireMember(2)]
		public uint Category { get; }

		/// <summary>
		/// 2 m_dispelType
		/// </summary>
		[WireMember(3)]
		public uint Dispel { get; }

		/// <summary>
		/// 3 m_mechanic
		/// </summary>
		[WireMember(4)]
		public SpellMechanic Mechanic { get; }

		/// <summary>
		/// 4  m_attribute
		/// </summary>
		[WireMember(5)]
		public SpellAtribute Attributes { get; }

		/// <summary>
		/// 5 m_attributesEx
		/// </summary>
		[WireMember(6)]
		public SpellAtributeEx AttributesEx { get; }

		/// <summary>
		/// 6        m_attributesExB
		/// </summary>
		[WireMember(7)]
		public SpellAtributeEx2 AttributesEx2 { get; }

		/// <summary>
		///  7        m_attributesExC
		/// </summary>
		[WireMember(8)]
		public SpellAtributeEx3 AttributesEx3 { get; }

		/// <summary>
		/// 8        m_attributesExD
		/// </summary>
		[WireMember(9)]
		public SpellAtributeEx4 AttributesEx4 { get; }

		/// <summary>
		/// 9        m_attributesExE
		/// </summary>
		[WireMember(10)]
		public SpellAtributeEx5 AttributesEx5 { get; }

		/// <summary>
		/// 10       m_attributesExF
		/// </summary>
		[WireMember(11)]
		public SpellAtributeEx6 AttributesEx6 { get; }

		/// <summary>
		/// 11       3.2.0 (0x20 - totems, 0x4 - paladin auras, etc...)
		/// </summary>
		[WireMember(12)]
		public SpellAtributeEx7 AttributesEx7 { get; }

		/// <summary>
		/// 12-13    m_shapeshiftMask
		/// </summary>
		[WireMember(13)]
		public ulong Stances { get; }

		/// <summary>
		/// 14-15    m_shapeshiftExclude
		/// </summary>
		[WireMember(14)]
		public ulong StancesNot { get; }

		/// <summary>
		/// 16       m_targets
		/// </summary>
		[WireMember(15)]
		public uint Targets { get; }

		//TODO: Is this mask right?
		/// <summary>
		/// 17       m_targetCreatureType
		/// </summary>
		[WireMember(16)]
		public CreatureTypeMask TargetCreatureType { get; }

		/// <summary>
		/// 18       m_requiresSpellFocus
		/// </summary>
		[WireMember(17)]
		public uint RequiresSpellFocus { get; }

		//TODO: What enum is this?
		/// <summary>
		/// 19       m_facingCasterFlags
		/// </summary>
		[WireMember(18)]
		public uint FacingCasterFlags { get; }

		/// <summary>
		/// 20       m_casterAuraState
		/// </summary>
		[WireMember(19)]
		public AuraState CasterAuraState { get; }

		/// <summary>
		/// 21       m_targetAuraState
		/// </summary>
		[WireMember(20)]
		public AuraState TargetAuraState { get; }

		/// <summary>
		/// 22       m_excludeCasterAuraState
		/// </summary>
		[WireMember(21)]
		public AuraState CasterAuraStateNot { get; }

		/// <summary>
		/// 23       m_excludeTargetAuraState
		/// </summary>
		[WireMember(22)]
		public AuraState TargetAuraStateNot { get; }

		/// <summary>
		/// 24       m_casterAuraSpell
		/// </summary>
		[WireMember(23)]
		public uint CasterAuraSpell { get; }

		/// <summary>
		/// 25       m_targetAuraSpell
		/// </summary>
		[WireMember(24)]
		public uint TargetAuraSpell { get; }

		/// <summary>
		/// 26       m_excludeCasterAuraSpell
		/// </summary>
		[WireMember(25)]
		public uint ExcludeCasterAuraSpell { get; }

		/// <summary>
		/// 27       m_excludeTargetAuraSpell
		/// </summary>
		[WireMember(26)]
		public uint ExcludeTargetAuraSpell { get; }

		/// <summary>
		/// 28       m_castingTimeIndex
		/// </summary>
		[WireMember(27)]
		public uint CastingTimeIndex { get; }

		/// <summary>
		/// 29       m_recoveryTime
		/// </summary>
		[WireMember(28)]
		public uint RecoveryTime { get; }

		/// <summary>
		/// 30       m_categoryRecoveryTime
		/// </summary>
		[WireMember(29)]
		public uint CategoryRecoveryTime { get; }

		/// <summary>
		/// 31       m_interruptFlags
		/// </summary>
		[WireMember(30)]
		public SpellInteruptFlags InterruptFlags { get; }

		/// <summary>
		/// 32       m_auraInterruptFlags
		/// </summary>
		[WireMember(31)]
		public SpellAuraInterruptFlags AuraInterruptFlags { get; }

		/// <summary>
		/// 33       m_channelInterruptFlags
		/// </summary>
		[WireMember(32)]
		public SpellChannelInterruptFlags ChannelInterruptFlags { get; }

		/// <summary>
		/// 34       m_procTypeMask
		/// </summary>
		[WireMember(33)]
		public ProcFlags ProcFlags { get; }

		/// <summary>
		/// 35       m_procChance
		/// </summary>
		[WireMember(34)]
		public uint ProcChance { get; }

		/// <summary>
		/// 36       m_procCharges
		/// </summary>
		[WireMember(35)]
		public uint ProcCharges { get; }

		/// <summary>
		/// 37       m_maxLevel
		/// </summary>
		[WireMember(36)]
		public uint MaxLevel { get; }

		/// <summary>
		/// 38       m_baseLevel
		/// </summary>
		[WireMember(37)]
		public uint BaseLevel { get; }

		/// <summary>
		/// 39       m_spellLevel
		/// </summary>
		[WireMember(38)]
		public uint SpellLevel { get; }

		/// <summary>
		/// 40       m_durationIndex
		/// </summary>
		[WireMember(39)]
		public uint DurationIndex { get; }

		//TODO: Is this the right enum?
		/// <summary>
		/// 41       m_powerType
		/// </summary>
		[WireMember(40)]
		public SpellCostPower PowerType { get; }

		/// <summary>
		/// 42       m_manaCost
		/// </summary>
		[WireMember(41)]
		public uint ManaCost { get; }

		/// <summary>
		/// 43       m_manaCostPerLevel
		/// </summary>
		[WireMember(42)]
		public uint ManaCostPerlevel { get; }

		/// <summary>
		/// 44       m_manaPerSecond
		/// </summary>
		[WireMember(43)]
		public uint ManaPerSecond { get; }

		/// <summary>
		/// 45       m_manaPerSecondPerLevel
		/// </summary>
		[WireMember(44)]
		public uint ManaPerSecondPerLevel { get; }

		/// <summary>
		/// 46       m_rangeIndex
		/// </summary>
		[WireMember(45)]
		public uint RangeIndex { get; }

		/// <summary>
		/// 47       m_speed
		/// </summary>
		[WireMember(46)]
		public float Speed { get; }

		/// <summary>
		/// 48       m_modalNextSpell not used
		/// </summary>
		[WireMember(47)]
		public uint ModalNextSpell { get; }

		/// <summary>
		/// 49       m_cumulativeAura
		/// </summary>
		[WireMember(48)]
		public uint StackAmount { get; }

		[WireMember(49)]
		public RequiredReagentData ReagentsRequired { get; }

		/// <summary>
		///  68       m_equippedItemClass (value)
		/// </summary>
		[WireMember(52)]
		public ItemClassType EquippedItemClass { get; }

		/// <summary>
		/// 69       m_equippedItemSubclass (mask)
		/// See subclass enums.
		/// </summary>
		[WireMember(53)]
		public int EquippedItemSubClassMask { get; }

		/// <summary>
		/// 70       m_equippedItemInvTypes (mask)
		/// </summary>
		[WireMember(54)]
		public InventoryTypeMask EquippedItemInventoryTypeMask { get; }

		[WireMember(55)]
		public SpellEffectData SpellEffectInformation { get; }

		/// <summary>
		/// 131-132  m_spellVisualID
		/// </summary>
		[WireMember(75)]
		[KnownSize(2)]
		public uint[] SpellVisual { get; }

		/// <summary>
		///  133      m_spellIconID
		/// </summary>
		[WireMember(76)]
		public uint SpellIconID { get; }

		/// <summary>
		/// 134      m_activeIconID
		/// </summary>
		[WireMember(77)]
		public uint ActiveIconID { get; }

		/// <summary>
		/// 135      m_spellPriority not used
		/// </summary>
		[WireMember(78)]
		public uint SpellPriority { get; }

		/// <summary>
		/// 136-151  m_name_lang
		/// </summary>
		[WireMember(79)]
		private LocalizedStringDBC<TStringType> _SpellName { get; }

		/// <summary>
		/// 152      not used
		/// </summary>
		[WireMember(80)]
		public uint SpellNameFlag { get; }

		/// <summary>
		/// 153-168  m_nameSubtext_lang
		/// </summary>
		[WireMember(81)]
		private LocalizedStringDBC<TStringType> _Rank { get; }

		/// <summary>
		/// 169      not used
		/// </summary>
		[WireMember(82)]
		public uint RankFlags { get; }

		/// <summary>
		///  170-185  m_description_lang not used
		/// </summary>
		[WireMember(83)]
		private LocalizedStringDBC<TStringType> _Description { get; }

		/// <summary>
		/// 186      not used
		/// </summary>
		[WireMember(84)]
		public uint DescriptionFlags { get; }

		/// <summary>
		/// 187-202  m_auraDescription_lang not used
		/// </summary>
		[WireMember(85)]
		[KnownSize(DBCConstants.MaxDbcLocale)]
		private LocalizedStringDBC<TStringType> _ToolTip { get; }

		/// <summary>
		/// 203      not used
		/// </summary>
		[WireMember(86)]
		public uint ToolTipFlags { get; }

		/// <summary>
		/// 204      m_manaCostPct
		/// </summary>
		[WireMember(87)]
		public uint ManaCostPercentage { get; }

		/// <summary>
		///  205      m_startRecoveryCategory
		/// </summary>
		[WireMember(88)]
		public uint StartRecoveryCategory { get; }

		/// <summary>
		/// 206      m_startRecoveryTime
		/// </summary>
		[WireMember(89)]
		public uint StartRecoveryTime { get; }

		/// <summary>
		/// 207      m_maxTargetLevel
		/// </summary>
		[WireMember(90)]
		public uint MaxTargetLevel { get; }

		/// <summary>
		/// 208      m_spellClassSet
		/// </summary>
		[WireMember(91)]
		public SpellFamilyName SpellFamilyName { get; }

		/// <summary>
		/// 209-211  m_spellClassMask
		/// </summary>
		[WireMember(92)]
		[KnownSize(3)]
		public uint[] SpellFamilyFlags { get; }

		/// <summary>
		/// 212      m_maxTargets
		/// </summary>
		[WireMember(93)]
		public uint MaxAffectedTargets { get; }

		/// <summary>
		/// 213      m_defenseType
		/// </summary>
		[WireMember(94)]
		public SpellDamageClassType DmgClass { get; }

		/// <summary>
		/// 214      m_preventionType
		/// </summary>
		[WireMember(95)]
		public SpellPreventionType PreventionType { get; }

		/// <summary>
		/// 215      m_stanceBarOrder not used
		/// </summary>
		[WireMember(96)]
		public uint StanceBarOrder { get; }

		/// <summary>
		/// 216-218  m_effectChainAmplitude
		/// </summary>
		[WireMember(97)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public float[] DmgMultiplier { get; }

		/// <summary>
		/// 219      m_minFactionID not used
		/// </summary>
		[WireMember(98)]
		public uint MinFactionId { get; }

		/// <summary>
		/// 220      m_minReputation not used
		/// </summary>
		[WireMember(99)]
		public uint MinReputation { get; }

		/// <summary>
		/// 221      m_requiredAuraVision not used
		/// </summary>
		[WireMember(100)]
		public uint RequiredAuraVision { get; }

		/// <summary>
		/// 222-223  m_requiredTotemCategoryID
		/// </summary>
		[WireMember(101)]
		[KnownSize(2)]
		public uint[] TotemCategory { get; }

		/// <summary>
		/// 224      m_requiredAreaGroupId
		/// </summary>
		[WireMember(102)]
		public int AreaGroupId { get; }

		/// <summary>
		/// 225      m_schoolMask
		/// </summary>
		[WireMember(103)]
		public SpellSchoolMask SchoolMask { get; }

		/// <summary>
		/// 226      m_runeCostID
		/// </summary>
		[WireMember(104)]
		public uint RuneCostID { get; }

		/// <summary>
		/// 227      m_spellMissileID not used
		/// </summary>
		[WireMember(105)]
		public uint SpellMissileID { get; }

		/// <summary>
		/// 228      PowerDisplay.dbc, new in 3.1
		/// </summary>
		[WireMember(106)]
		public uint PowerDisplayId { get; }

		/// <summary>
		/// 229-231  3.2.0
		/// </summary>
		[WireMember(107)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public float[] DamageCoeficient { get; }

		/// <summary>
		/// 232      3.2.0
		/// </summary>
		[WireMember(108)]
		public uint SpellDescriptionVariableID { get; }

		/// <summary>
		/// 233      3.3.0
		/// </summary>
		[WireMember(109)]
		public uint SpellDifficultyId { get; }
		// 239      3.3.0
		
		//Serializer ctor
		protected SpellDBCEntry()
		{
			
		}
	}
}
