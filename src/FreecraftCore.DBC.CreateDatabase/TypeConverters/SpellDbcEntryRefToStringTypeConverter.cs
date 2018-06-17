using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class SpellDbcEntryRefToStringTypeConverter : ITypeConverterProvider<SpellEntry<StringDBCReference>, SpellEntry<string>>
	{
		private ITypeConverterProvider<LocalizedStringDBC<StringDBCReference>, LocalizedStringDBC<string>> LocalizedStringRefToStringConverter { get; }

		/// <inheritdoc />
		public SpellDbcEntryRefToStringTypeConverter([NotNull] ITypeConverterProvider<LocalizedStringDBC<StringDBCReference>, LocalizedStringDBC<string>> localizedStringRefToStringConverter)
		{
			LocalizedStringRefToStringConverter = localizedStringRefToStringConverter ?? throw new ArgumentNullException(nameof(localizedStringRefToStringConverter));
		}

		/// <inheritdoc />
		public SpellEntry<string> Convert(SpellEntry<StringDBCReference> fromObject)
		{
			if(fromObject == null) throw new ArgumentNullException(nameof(fromObject));

			//TODO: Speed this up
			return new SpellEntry<string>(fromObject.SpellId,
				fromObject.Category,
				fromObject.Dispel,
				fromObject.Mechanic,
				fromObject.Attributes,
				fromObject.AttributesEx,
				fromObject.AttributesEx2,
				fromObject.AttributesEx3,
				fromObject.AttributesEx4,
				fromObject.AttributesEx5,
				fromObject.AttributesEx6,
				fromObject.AttributesEx7,
				fromObject.Stances,
				fromObject.StancesNot,
				fromObject.Targets,
				fromObject.TargetCreatureType,
				fromObject.RequiresSpellFocus,
				fromObject.FacingCasterFlags,
				fromObject.CasterAuraState,
				fromObject.TargetAuraState,
				fromObject.CasterAuraStateNot,
				fromObject.TargetAuraStateNot,
				fromObject.CasterAuraSpell,
				fromObject.TargetAuraSpell,
				fromObject.ExcludeCasterAuraSpell,
				fromObject.ExcludeTargetAuraSpell,
				fromObject.CastingTimeIndex,
				fromObject.RecoveryTime,
				fromObject.CategoryRecoveryTime,
				fromObject.InterruptFlags,
				fromObject.AuraInterruptFlags,
				fromObject.ChannelInterruptFlags,
				fromObject.ProcFlags,
				fromObject.ProcChance,
				fromObject.ProcCharges,
				fromObject.MaxLevel,
				fromObject.BaseLevel,
				fromObject.SpellLevel,
				fromObject.DurationIndex,
				fromObject.PowerType,
				fromObject.ManaCost,
				fromObject.ManaCostPerlevel,
				fromObject.ManaPerSecond,
				fromObject.ManaPerSecondPerLevel,
				fromObject.RangeIndex,
				fromObject.Speed,
				fromObject.ModalNextSpell,
				fromObject.StackAmount,
				fromObject.ReagentsRequired,
				fromObject.EquippedItemClass,
				fromObject.EquippedItemSubClassMask,
				fromObject.EquippedItemInventoryTypeMask,
				fromObject.SpellEffectInformation,
				fromObject.SpellVisual,
				fromObject.SpellIconID,
				fromObject.ActiveIconID,
				fromObject.SpellPriority,
				LocalizedStringRefToStringConverter.Convert(fromObject.SpellName),
				LocalizedStringRefToStringConverter.Convert(fromObject.Rank),
				LocalizedStringRefToStringConverter.Convert(fromObject.Description),
				LocalizedStringRefToStringConverter.Convert(fromObject.ToolTip),
				fromObject.ManaCostPercentage,
				fromObject.StartRecoveryCategory,
				fromObject.StartRecoveryTime,
				fromObject.MaxTargetLevel,
				fromObject.SpellFamilyName,
				fromObject.SpellFamilyFlags,
				fromObject.MaxAffectedTargets,
				fromObject.DmgClass,
				fromObject.PreventionType,
				fromObject.StanceBarOrder,
				fromObject.DmgMultiplier,
				fromObject.MinFactionId,
				fromObject.MinReputation,
				fromObject.RequiredAuraVision,
				fromObject.TotemCategory,
				fromObject.AreaGroupId,
				fromObject.SchoolMask,
				fromObject.RuneCostID,
				fromObject.SpellMissileID,
				fromObject.PowerDisplayId,
				fromObject.DamageCoeficient,
				fromObject.SpellDescriptionVariableID,
				fromObject.SpellDifficultyId);
		}
	}
}
