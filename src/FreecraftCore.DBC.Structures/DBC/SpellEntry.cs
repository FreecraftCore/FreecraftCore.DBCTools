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
	[GenericDbcModel(typeof(SpellEntry<StringDBCReference>), typeof(SpellEntry<string>))]
	[Table("Spell")]
	[JsonObject]
	[WireDataContract]
	public sealed class SpellEntry<TStringType> : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		public uint EntryId => (uint)SpellId;

		/// <summary>
		/// 0 m_ID
		/// </summary>
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		[WireMember(1)]
		public int SpellId { get; private set; }

		/// <summary>
		/// 1 m_category
		/// </summary>
		[WireMember(2)]
		public uint Category { get; private set; }

		/// <summary>
		/// 2 m_dispelType
		/// </summary>
		[WireMember(3)]
		public uint Dispel { get; private set; }

		/// <summary>
		/// 3 m_mechanic
		/// </summary>
		[WireMember(4)]
		public SpellMechanic Mechanic { get; private set; }

		/// <summary>
		/// 4  m_attribute
		/// </summary>
		[WireMember(5)]
		public SpellAtribute Attributes { get; private set; }

		/// <summary>
		/// 5 m_attributesEx
		/// </summary>
		[WireMember(6)]
		public SpellAtributeEx AttributesEx { get; private set; }

		/// <summary>
		/// 6        m_attributesExB
		/// </summary>
		[WireMember(7)]
		public SpellAtributeEx2 AttributesEx2 { get; private set; }

		/// <summary>
		///  7        m_attributesExC
		/// </summary>
		[WireMember(8)]
		public SpellAtributeEx3 AttributesEx3 { get; private set; }

		/// <summary>
		/// 8        m_attributesExD
		/// </summary>
		[WireMember(9)]
		public SpellAtributeEx4 AttributesEx4 { get; private set; }

		/// <summary>
		/// 9        m_attributesExE
		/// </summary>
		[WireMember(10)]
		public SpellAtributeEx5 AttributesEx5 { get; private set; }

		/// <summary>
		/// 10       m_attributesExF
		/// </summary>
		[WireMember(11)]
		public SpellAtributeEx6 AttributesEx6 { get; private set; }

		/// <summary>
		/// 11       3.2.0 (0x20 - totems, 0x4 - paladin auras, etc...)
		/// </summary>
		[WireMember(12)]
		public SpellAtributeEx7 AttributesEx7 { get; private set; }

		/// <summary>
		/// 12-13    m_shapeshiftMask
		/// </summary>
		[WireMember(13)]
		public ulong Stances { get; private set; }

		/// <summary>
		/// 14-15    m_shapeshiftExclude
		/// </summary>
		[WireMember(14)]
		public ulong StancesNot { get; private set; }

		/// <summary>
		/// 16       m_targets
		/// </summary>
		[WireMember(15)]
		public uint Targets { get; private set; }

		//TODO: Is this mask right?
		/// <summary>
		/// 17       m_targetCreatureType
		/// </summary>
		[WireMember(16)]
		public CreatureTypeMask TargetCreatureType { get; private set; }

		/// <summary>
		/// 18       m_requiresSpellFocus
		/// </summary>
		[WireMember(17)]
		public uint RequiresSpellFocus { get; private set; }

		//TODO: What enum is this?
		/// <summary>
		/// 19       m_facingCasterFlags
		/// </summary>
		[WireMember(18)]
		public uint FacingCasterFlags { get; private set; }

		/// <summary>
		/// 20       m_casterAuraState
		/// </summary>
		[WireMember(19)]
		public AuraState CasterAuraState { get; private set; }

		/// <summary>
		/// 21       m_targetAuraState
		/// </summary>
		[WireMember(20)]
		public AuraState TargetAuraState { get; private set; }

		/// <summary>
		/// 22       m_excludeCasterAuraState
		/// </summary>
		[WireMember(21)]
		public AuraState CasterAuraStateNot { get; private set; }

		/// <summary>
		/// 23       m_excludeTargetAuraState
		/// </summary>
		[WireMember(22)]
		public AuraState TargetAuraStateNot { get; private set; }

		/// <summary>
		/// 24       m_casterAuraSpell
		/// </summary>
		[WireMember(23)]
		public uint CasterAuraSpell { get; private set; }

		/// <summary>
		/// 25       m_targetAuraSpell
		/// </summary>
		[WireMember(24)]
		public uint TargetAuraSpell { get; private set; }

		/// <summary>
		/// 26       m_excludeCasterAuraSpell
		/// </summary>
		[WireMember(25)]
		public uint ExcludeCasterAuraSpell { get; private set; }

		/// <summary>
		/// 27       m_excludeTargetAuraSpell
		/// </summary>
		[WireMember(26)]
		public uint ExcludeTargetAuraSpell { get; private set; }

		/// <summary>
		/// 28       m_castingTimeIndex
		/// </summary>
		[WireMember(27)]
		public uint CastingTimeIndex { get; private set; }

		/// <summary>
		/// 29       m_recoveryTime
		/// </summary>
		[WireMember(28)]
		public uint RecoveryTime { get; private set; }

		/// <summary>
		/// 30       m_categoryRecoveryTime
		/// </summary>
		[WireMember(29)]
		public uint CategoryRecoveryTime { get; private set; }

		/// <summary>
		/// 31       m_interruptFlags
		/// </summary>
		[WireMember(30)]
		public SpellInteruptFlags InterruptFlags { get; private set; }

		/// <summary>
		/// 32       m_auraInterruptFlags
		/// </summary>
		[WireMember(31)]
		public SpellAuraInterruptFlags AuraInterruptFlags { get; private set; }

		/// <summary>
		/// 33       m_channelInterruptFlags
		/// </summary>
		[WireMember(32)]
		public SpellChannelInterruptFlags ChannelInterruptFlags { get; private set; }

		/// <summary>
		/// 34       m_procTypeMask
		/// </summary>
		[WireMember(33)]
		public ProcFlags ProcFlags { get; private set; }

		/// <summary>
		/// 35       m_procChance
		/// </summary>
		[WireMember(34)]
		public uint ProcChance { get; private set; }

		/// <summary>
		/// 36       m_procCharges
		/// </summary>
		[WireMember(35)]
		public uint ProcCharges { get; private set; }

		/// <summary>
		/// 37       m_maxLevel
		/// </summary>
		[WireMember(36)]
		public uint MaxLevel { get; private set; }

		/// <summary>
		/// 38       m_baseLevel
		/// </summary>
		[WireMember(37)]
		public uint BaseLevel { get; private set; }

		/// <summary>
		/// 39       m_spellLevel
		/// </summary>
		[WireMember(38)]
		public uint SpellLevel { get; private set; }

		/// <summary>
		/// 40       m_durationIndex
		/// </summary>
		[WireMember(39)]
		public uint DurationIndex { get; private set; }

		//TODO: Is this the right enum?
		/// <summary>
		/// 41       m_powerType
		/// </summary>
		[WireMember(40)]
		public SpellCostPower PowerType { get; private set; }

		/// <summary>
		/// 42       m_manaCost
		/// </summary>
		[WireMember(41)]
		public uint ManaCost { get; private set; }

		/// <summary>
		/// 43       m_manaCostPerLevel
		/// </summary>
		[WireMember(42)]
		public uint ManaCostPerlevel { get; private set; }

		/// <summary>
		/// 44       m_manaPerSecond
		/// </summary>
		[WireMember(43)]
		public uint ManaPerSecond { get; private set; }

		/// <summary>
		/// 45       m_manaPerSecondPerLevel
		/// </summary>
		[WireMember(44)]
		public uint ManaPerSecondPerLevel { get; private set; }

		/// <summary>
		/// 46       m_rangeIndex
		/// </summary>
		[WireMember(45)]
		public uint RangeIndex { get; private set; }

		/// <summary>
		/// 47       m_speed
		/// </summary>
		[WireMember(46)]
		public float Speed { get; private set; }

		/// <summary>
		/// 48       m_modalNextSpell not used
		/// </summary>
		[WireMember(47)]
		public uint ModalNextSpell { get; private set; }

		/// <summary>
		/// 49       m_cumulativeAura
		/// </summary>
		[WireMember(48)]
		public uint StackAmount { get; private set; }

		[WireMember(49)]
		public RequiredReagentData ReagentsRequired { get; private set; }

		/// <summary>
		///  68       m_equippedItemClass (value)
		/// </summary>
		[WireMember(52)]
		public ItemClassType EquippedItemClass { get; private set; }

		/// <summary>
		/// 69       m_equippedItemSubclass (mask)
		/// See subclass enums.
		/// </summary>
		[WireMember(53)]
		public int EquippedItemSubClassMask { get; private set; }

		/// <summary>
		/// 70       m_equippedItemInvTypes (mask)
		/// </summary>
		[WireMember(54)]
		public InventoryTypeMask EquippedItemInventoryTypeMask { get; private set; }

		[WireMember(55)]
		public SpellEffectData SpellEffectInformation { get; private set; }

		/// <summary>
		/// 131-132  m_spellVisualID
		/// </summary>
		[WireMember(75)]
		public SpellVisualData SpellVisual { get; private set; }

		/// <summary>
		///  133      m_spellIconID
		/// </summary>
		[WireMember(76)]
		public uint SpellIconID { get; private set; }

		/// <summary>
		/// 134      m_activeIconID
		/// </summary>
		[WireMember(77)]
		public uint ActiveIconID { get; private set; }

		/// <summary>
		/// 135      m_spellPriority not used
		/// </summary>
		[WireMember(78)]
		public uint SpellPriority { get; private set; }

		/// <summary>
		/// 136-151  m_name_lang
		/// </summary>
		[WireMember(79)]
		public LocalizedStringDBC<TStringType> SpellName { get; set; }

		/// <summary>
		/// 153-168  m_nameSubtext_lang
		/// </summary>
		[WireMember(81)]
		public LocalizedStringDBC<TStringType> Rank { get; set; }

		/// <summary>
		///  170-185  m_description_lang not used
		/// </summary>
		[WireMember(83)]
		public LocalizedStringDBC<TStringType> Description { get; set; }

		/// <summary>
		/// 187-202  m_auraDescription_lang not used
		/// </summary>
		[WireMember(85)]
		public LocalizedStringDBC<TStringType> ToolTip { get; set; }

		/// <summary>
		/// 204      m_manaCostPct
		/// </summary>
		[WireMember(87)]
		public uint ManaCostPercentage { get; private set; }

		/// <summary>
		///  205      m_startRecoveryCategory
		/// </summary>
		[WireMember(88)]
		public uint StartRecoveryCategory { get; private set; }

		/// <summary>
		/// 206      m_startRecoveryTime
		/// </summary>
		[WireMember(89)]
		public uint StartRecoveryTime { get; private set; }

		/// <summary>
		/// 207      m_maxTargetLevel
		/// </summary>
		[WireMember(90)]
		public uint MaxTargetLevel { get; private set; }

		/// <summary>
		/// 208      m_spellClassSet
		/// </summary>
		[WireMember(91)]
		public SpellFamilyName SpellFamilyName { get; private set; }

		/// <summary>
		/// 209-211  m_spellClassMask
		/// </summary>
		[WireMember(92)]
		public Flags96<uint> SpellFamilyFlags { get; private set; }

		/// <summary>
		/// 212      m_maxTargets
		/// </summary>
		[WireMember(93)]
		public uint MaxAffectedTargets { get; private set; }

		/// <summary>
		/// 213      m_defenseType
		/// </summary>
		[WireMember(94)]
		public SpellDamageClassType DmgClass { get; private set; }

		/// <summary>
		/// 214      m_preventionType
		/// </summary>
		[WireMember(95)]
		public SpellPreventionType PreventionType { get; private set; }

		/// <summary>
		/// 215      m_stanceBarOrder not used
		/// </summary>
		[WireMember(96)]
		public uint StanceBarOrder { get; private set; }

		/// <summary>
		/// 216-218  m_effectChainAmplitude
		/// </summary>
		[WireMember(97)]
		public SpellEffectDataChunk<float> DmgMultiplier { get; private set; }

		/// <summary>
		/// 219      m_minFactionID not used
		/// </summary>
		[WireMember(98)]
		public uint MinFactionId { get; private set; }

		/// <summary>
		/// 220      m_minReputation not used
		/// </summary>
		[WireMember(99)]
		public uint MinReputation { get; private set; }

		/// <summary>
		/// 221      m_requiredAuraVision not used
		/// </summary>
		[WireMember(100)]
		public uint RequiredAuraVision { get; private set; }

		/// <summary>
		/// 222-223  m_requiredTotemCategoryID
		/// </summary>
		[WireMember(101)]
		public SpellTotemDataChunk<uint> TotemCategory { get; private set; }

		/// <summary>
		/// 224      m_requiredAreaGroupId
		/// </summary>
		[WireMember(102)]
		public int AreaGroupId { get; private set; }

		/// <summary>
		/// 225      m_schoolMask
		/// </summary>
		[WireMember(103)]
		public SpellSchoolMask SchoolMask { get; private set; }

		/// <summary>
		/// 226      m_runeCostID
		/// </summary>
		[WireMember(104)]
		public uint RuneCostID { get; private set; }

		/// <summary>
		/// 227      m_spellMissileID not used
		/// </summary>
		[WireMember(105)]
		public uint SpellMissileID { get; private set; }

		/// <summary>
		/// 228      PowerDisplay.dbc, new in 3.1
		/// </summary>
		[WireMember(106)]
		public uint PowerDisplayId { get; private set; }

		/// <summary>
		/// 229-231  3.2.0
		/// </summary>
		[WireMember(107)]
		public SpellEffectDataChunk<float> DamageCoeficient { get; private set; }

		/// <summary>
		/// 232      3.2.0
		/// </summary>
		[WireMember(108)]
		public uint SpellDescriptionVariableID { get; private set; }

		/// <summary>
		/// 233      3.3.0
		/// </summary>
		[WireMember(109)]
		public uint SpellDifficultyId { get; private set; }
		// 239      3.3.0

		/// <inheritdoc />
		public SpellEntry(int spellId, uint category, uint dispel, SpellMechanic mechanic, SpellAtribute attributes, SpellAtributeEx attributesEx, SpellAtributeEx2 attributesEx2, SpellAtributeEx3 attributesEx3, SpellAtributeEx4 attributesEx4, SpellAtributeEx5 attributesEx5, SpellAtributeEx6 attributesEx6, SpellAtributeEx7 attributesEx7, ulong stances, ulong stancesNot, uint targets, CreatureTypeMask targetCreatureType, uint requiresSpellFocus, uint facingCasterFlags, AuraState casterAuraState, AuraState targetAuraState, AuraState casterAuraStateNot, AuraState targetAuraStateNot, uint casterAuraSpell, uint targetAuraSpell, uint excludeCasterAuraSpell, uint excludeTargetAuraSpell, uint castingTimeIndex, uint recoveryTime, uint categoryRecoveryTime, SpellInteruptFlags interruptFlags, SpellAuraInterruptFlags auraInterruptFlags, SpellChannelInterruptFlags channelInterruptFlags, ProcFlags procFlags, uint procChance, uint procCharges, uint maxLevel, uint baseLevel, uint spellLevel, uint durationIndex, SpellCostPower powerType, uint manaCost, uint manaCostPerlevel, uint manaPerSecond, uint manaPerSecondPerLevel, uint rangeIndex, float speed, uint modalNextSpell, uint stackAmount, RequiredReagentData reagentsRequired, ItemClassType equippedItemClass, int equippedItemSubClassMask, InventoryTypeMask equippedItemInventoryTypeMask, SpellEffectData spellEffectInformation, SpellVisualData spellVisual, uint spellIconId, uint activeIconId, uint spellPriority, LocalizedStringDBC<TStringType> spellName, LocalizedStringDBC<TStringType> rank, LocalizedStringDBC<TStringType> description, LocalizedStringDBC<TStringType> toolTip, uint manaCostPercentage, uint startRecoveryCategory, uint startRecoveryTime, uint maxTargetLevel, SpellFamilyName spellFamilyName, Flags96<uint> spellFamilyFlags, uint maxAffectedTargets, SpellDamageClassType dmgClass, SpellPreventionType preventionType, uint stanceBarOrder, SpellEffectDataChunk<float> dmgMultiplier, uint minFactionId, uint minReputation, uint requiredAuraVision, SpellTotemDataChunk<uint> totemCategory, int areaGroupId, SpellSchoolMask schoolMask, uint runeCostId, uint spellMissileId, uint powerDisplayId, SpellEffectDataChunk<float> damageCoeficient, uint spellDescriptionVariableId, uint spellDifficultyId)
		{
			SpellId = spellId;
			Category = category;
			Dispel = dispel;
			Mechanic = mechanic;
			Attributes = attributes;
			AttributesEx = attributesEx;
			AttributesEx2 = attributesEx2;
			AttributesEx3 = attributesEx3;
			AttributesEx4 = attributesEx4;
			AttributesEx5 = attributesEx5;
			AttributesEx6 = attributesEx6;
			AttributesEx7 = attributesEx7;
			Stances = stances;
			StancesNot = stancesNot;
			Targets = targets;
			TargetCreatureType = targetCreatureType;
			RequiresSpellFocus = requiresSpellFocus;
			FacingCasterFlags = facingCasterFlags;
			CasterAuraState = casterAuraState;
			TargetAuraState = targetAuraState;
			CasterAuraStateNot = casterAuraStateNot;
			TargetAuraStateNot = targetAuraStateNot;
			CasterAuraSpell = casterAuraSpell;
			TargetAuraSpell = targetAuraSpell;
			ExcludeCasterAuraSpell = excludeCasterAuraSpell;
			ExcludeTargetAuraSpell = excludeTargetAuraSpell;
			CastingTimeIndex = castingTimeIndex;
			RecoveryTime = recoveryTime;
			CategoryRecoveryTime = categoryRecoveryTime;
			InterruptFlags = interruptFlags;
			AuraInterruptFlags = auraInterruptFlags;
			ChannelInterruptFlags = channelInterruptFlags;
			ProcFlags = procFlags;
			ProcChance = procChance;
			ProcCharges = procCharges;
			MaxLevel = maxLevel;
			BaseLevel = baseLevel;
			SpellLevel = spellLevel;
			DurationIndex = durationIndex;
			PowerType = powerType;
			ManaCost = manaCost;
			ManaCostPerlevel = manaCostPerlevel;
			ManaPerSecond = manaPerSecond;
			ManaPerSecondPerLevel = manaPerSecondPerLevel;
			RangeIndex = rangeIndex;
			Speed = speed;
			ModalNextSpell = modalNextSpell;
			StackAmount = stackAmount;
			ReagentsRequired = reagentsRequired;
			EquippedItemClass = equippedItemClass;
			EquippedItemSubClassMask = equippedItemSubClassMask;
			EquippedItemInventoryTypeMask = equippedItemInventoryTypeMask;
			SpellEffectInformation = spellEffectInformation;
			SpellVisual = spellVisual;
			SpellIconID = spellIconId;
			ActiveIconID = activeIconId;
			SpellPriority = spellPriority;
			SpellName = spellName;
			Rank = rank;
			Description = description;
			ToolTip = toolTip;
			ManaCostPercentage = manaCostPercentage;
			StartRecoveryCategory = startRecoveryCategory;
			StartRecoveryTime = startRecoveryTime;
			MaxTargetLevel = maxTargetLevel;
			SpellFamilyName = spellFamilyName;
			SpellFamilyFlags = spellFamilyFlags;
			MaxAffectedTargets = maxAffectedTargets;
			DmgClass = dmgClass;
			PreventionType = preventionType;
			StanceBarOrder = stanceBarOrder;
			DmgMultiplier = dmgMultiplier;
			MinFactionId = minFactionId;
			MinReputation = minReputation;
			RequiredAuraVision = requiredAuraVision;
			TotemCategory = totemCategory;
			AreaGroupId = areaGroupId;
			SchoolMask = schoolMask;
			RuneCostID = runeCostId;
			SpellMissileID = spellMissileId;
			PowerDisplayId = powerDisplayId;
			DamageCoeficient = damageCoeficient;
			SpellDescriptionVariableID = spellDescriptionVariableId;
			SpellDifficultyId = spellDifficultyId;
		}
		
		//Serializer ctor
		public SpellEntry()
		{
			
		}
	}
}
