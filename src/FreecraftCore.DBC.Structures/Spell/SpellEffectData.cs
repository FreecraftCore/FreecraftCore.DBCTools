using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class SpellEffectData
	{
		/// <summary>
		/// 71-73    m_effect
		/// </summary>
		[WireMember(55)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public SpellEffect[] Effect { get; }

		/// <summary>
		/// 74-76    m_effectDieSides
		/// </summary>
		[WireMember(56)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public int[] EffectDieSides { get; }

		/// <summary>
		/// 77-79    m_effectRealPointsPerLevel
		/// </summary>
		[WireMember(57)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public float[] EffectRealPointsPerLevel { get; }

		/// <summary>
		/// 80-82    m_effectBasePoints (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
		/// </summary>
		[WireMember(58)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public int[] EffectBasePoints { get; }

		/// <summary>
		/// 83-85    m_effectMechanic
		/// </summary>
		[WireMember(59)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public SpellMechanic[] EffectMechanic { get; }

		/// <summary>
		/// 86-88    m_implicitTargetA
		/// </summary>
		[WireMember(60)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public SpellTargetType[] EffectImplicitTargetA { get; }

		/// <summary>
		/// 89-91    m_implicitTargetB
		/// </summary>
		[WireMember(61)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public SpellTargetType[] EffectImplicitTargetB { get; }

		/// <summary>
		/// 92-94    m_effectRadiusIndex - spellradius.dbc
		/// </summary>
		[WireMember(62)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public uint[] EffectRadiusIndex { get; }

		/// <summary>
		/// 95-97    m_effectAura
		/// </summary>
		[WireMember(63)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public AuraType[] EffectApplyAuraName { get; }

		/// <summary>
		/// 98-100   m_effectAuraPeriod
		/// </summary>
		[WireMember(64)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public uint[] EffectAmplitude { get; }

		/// <summary>
		/// 101-103  m_effectAmplitude
		/// </summary>
		[WireMember(65)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public float[] EffectMultipleValue { get; }

		/// <summary>
		///  104-106  m_effectChainTargets
		/// </summary>
		[WireMember(66)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public uint[] EffectChainTarget { get; }

		/// <summary>
		/// 107-109  m_effectItemType
		/// </summary>
		[WireMember(67)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public uint[] EffectItemType { get; }

		/// <summary>
		/// 110-112  m_effectMiscValue
		/// </summary>
		[WireMember(68)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public int[] EffectMiscValue { get; }

		/// <summary>
		/// 113-115  m_effectMiscValueB
		/// </summary>
		[WireMember(69)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public int[] EffectMiscValueB { get; }

		/// <summary>
		/// 116-118  m_effectTriggerSpell
		/// </summary>
		[WireMember(70)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public uint[] EffectTriggerSpell { get; }

		/// <summary>
		/// 119-121  m_effectPointsPerCombo
		/// </summary>
		[WireMember(71)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public float[] EffectPointsPerComboPoint { get; }

		//TODO: TC created some weird Flags96 to handle these fields
		/// <summary>
		/// 122-124  m_effectSpellClassMaskA, effect 0
		/// </summary>
		[WireMember(72)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public uint[] EffectSpellClassMaskA { get; }

		/// <summary>
		/// 125-127  m_effectSpellClassMaskB, effect 1
		/// </summary>
		[WireMember(73)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public uint[] EffectSpellClassMaskB { get; }

		/// <summary>
		/// 128-130  m_effectSpellClassMaskC, effect 2
		/// </summary>
		[WireMember(74)]
		[KnownSize(DBCConstants.MaxEffectIndex)]
		public uint[] EffectSpellClassMaskC { get; }

		protected SpellEffectData()
		{
			
		}
	}
}
