using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	public sealed class DataBaseClientFilesDatabaseContext : DbContext
	{
		/// <summary>
		/// Represents the Spell.dbc table.
		/// </summary>
		public DbSet<SpellEntry<string>> Spells { get; set; }

		/// <summary>
		/// Represents the Item.dbc table.
		/// </summary>
		public DbSet<ItemEntry> Items { get; set; }

		/// <summary>
		/// Represents the SkillLineAbility.dbc
		/// </summary>
		public DbSet<SkillLineAbilityEntry> SkillLineAbilities { get; set; }

		/// <summary>
		/// Represents the SpellCastTimes.dbc
		/// </summary>
		public DbSet<SpellCastTimesEntry> SpellCastTimes { get; set; }

		/// <summary>
		/// Represents the SpellDifficuly.dbc
		/// </summary>
		public DbSet<SpellDifficultyEntry> SpellDifficulties { get; set; }

		/// <summary>
		/// Represents the SpellDuration.dbc
		/// </summary>
		public DbSet<SpellDurationEntry> SpellDurations { get; set; }

		/// <summary>
		/// Represents the SpellRadius.dbc
		/// </summary>
		public DbSet<SpellRadiusEntry> SpellRadius { get; set; }

		/// <summary>
		/// Represents the AreaTrigger.dbc
		/// </summary>
		public DbSet<AreaTriggerEntry> AreaTriggers { get; set; }

		/// <summary>
		/// Represents the SpellRange.dbc
		/// </summary>
		public DbSet<SpellRangeEntry<string>> SpellRanges { get; set; }

		public DbSet<ProfanityNamesEntry<string>> NamesProfanity { get; set; }

		public DbSet<MapEntry<string>> Maps { get; set; }

		public DataBaseClientFilesDatabaseContext([NotNull] DbContextOptions<DataBaseClientFilesDatabaseContext> options)
			: base(options)
		{

		}

#if DATABASEMIGRATION
		/// <inheritdoc />
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseMySql("Server=127.0.0.1;Port=3307;Database=client.dbc;Uid=root;Pwd=test;");
		}
#endif

		/// <inheritdoc />
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			/*modelBuilder
				.Entity<SpellEntry<string>>()
				.OwnsOne(p => p.ReagentsRequired, builder =>
				{
					builder.OwnsOne(r => r.ReagentId);
					builder.OwnsOne(r => r.Totem);
					builder.OwnsOne(r => r.ReagentCount);
				})
				.OwnsOne(p => p.SpellEffectInformation, builder =>
				{
					builder.OwnsOne(r => r.Effect);
					builder.OwnsOne(r => r.EffectAmplitude);
					builder.OwnsOne(r => r.EffectChainTarget);
					builder.OwnsOne(r => r.EffectDieSides);
					builder.OwnsOne(r => r.EffectImplicitTargetA);
					builder.OwnsOne(r => r.EffectImplicitTargetB);
					builder.OwnsOne(r => r.EffectItemType);
					builder.OwnsOne(r => r.EffectMechanic);
					builder.OwnsOne(r => r.EffectMiscValue);
					builder.OwnsOne(r => r.EffectApplyAuraName);
					builder.OwnsOne(r => r.EffectBasePoints);
					builder.OwnsOne(r => r.EffectMiscValueB);
					builder.OwnsOne(r => r.EffectMultipleValue);
					builder.OwnsOne(r => r.EffectPointsPerComboPoint);
					builder.OwnsOne(r => r.EffectRadiusIndex);
					builder.OwnsOne(r => r.EffectRealPointsPerLevel);
					builder.OwnsOne(r => r.EffectSpellClassMaskA);
					builder.OwnsOne(r => r.EffectSpellClassMaskB);
					builder.OwnsOne(r => r.EffectSpellClassMaskC);
					builder.OwnsOne(r => r.EffectTriggerSpell);
				});

			modelBuilder.Entity<AreaTriggerEntry>().OwnsOne(a => a.Position);
			modelBuilder.Entity<AreaTriggerEntry>().OwnsOne(a => a.UnalignedBoxDimension);*/

			//Important to show internal fields.
			foreach (string name in MapEntry<string>.INTERNAL_FIELD_NAMES)
				modelBuilder.Entity<MapEntry<string>>().Property(name);

			//modelBuilder.Entity<MapEntry<string>>().OwnsOne()
		}

		public DataBaseClientFilesDatabaseContext()
		{
			
		}
	}
}
