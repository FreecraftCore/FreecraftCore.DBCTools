using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reflect.Extent;

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

		public DbSet<AchievementEntry<string>> Achievements { get; set; }

		public DbSet<AchievementCategoryEntry<string>> AchievementCategory { get; set; }

		public DbSet<AchievementCriteriaEntry<string>> AchievementCriteria { get; set; }

		public DbSet<SpellItemEnchantmentEntry<string>> SpellItemEnchantment { get; set; }

		public DbSet<AreaTableEntry<string>> AreaTable { get; set; }

		public DbSet<ItemDisplayInfoEntry<string>> ItemDisplayInfo { get; set; }

		public DbSet<LoadingScreensEntry<string>> LoadingScreens { get; set; }

		public DbSet<FactionEntry<string>> Factions { get; set; }

		public DbSet<FactionTemplateEntry> FactionTemplates { get; set; }

		public DbSet<FactionGroupEntry<string>> FactionGroups { get; set; }

		public DbSet<UnitBloodLevelsEntry> UnitBloodLevels { get; set; }

		public DbSet<FootprintTexturesEntry<string>> FootprintTextures { get; set; }
		
		public DbSet<CameraShakesEntry> CameraShakes { get; set; }

		public DbSet<SoundEntriesEntry<string>> SoundEntries { get; set; }

		public DbSet<CreatureSoundDataEntry> CreatureSoundDatas { get; set; }

		public DbSet<CreatureModelDataEntry<string>> CreatureModelDatas { get; set; }

		public DbSet<CreatureDisplayInfoExtraEntry<string>> CreatureDisplayInfoExtras { get; set; }

		public DbSet<UnitBloodEntry<string>> UnitBloodEntries { get; set; }

		public DbSet<NPCSoundsEntry> NpcSoundEntries { get; set; }

		public DbSet<ParticleColorEntry> ParticleColors { get; set; }

		public DbSet<ObjectEffectPackageEntry<string>> ObjectEffectPackages { get; set; }

		public DbSet<CreatureDisplayInfoEntry<string>> CreatureDisplayInfos { get; set; }

		public DbSet<LanguagesEntry<string>> Languages { get; set; }

		public DbSet<CreatureTypeEntry<string>> CreatureTypes { get; set; }

		public DbSet<CinematicCameraEntry<string>> CinematicCameras { get; set; }

		public DbSet<CinematicSequencesEntry> CinematicSequences { get; set; }

		public DbSet<ChrRacesEntry<string>> ChrRaces { get; set; }

		public DbSet<CharTitlesEntry<string>> CharTitles { get; set; }

		public DbSet<LanguageWordsEntry<string>> LanguageWords { get; set; }

		public DbSet<QuestInfoEntry<string>> QuestInfos { get; set; }

		public DbSet<QuestSortEntry<string>> QuestSort { get; set; }

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

			modelBuilder
				.Entity<AreaTableEntry<string>>()
				.HasIndex(a => a.AreaBit)
				.IsUnique();

			modelBuilder
				.Entity<CharTitlesEntry<string>>()
				.HasIndex(a => a.TitleBit)
				.IsUnique();

			AddAllInternalFields(modelBuilder.Entity<MapEntry<string>>());
			AddAllInternalFields(modelBuilder.Entity<LoadingScreensEntry<string>>());
			AddAllInternalFields(modelBuilder.Entity<CreatureDisplayInfoExtraEntry<string>>());
			AddAllInternalFields(modelBuilder.Entity<CinematicSequencesEntry>());
			AddAllInternalFields(modelBuilder.Entity<ChrRacesEntry<string>>());
		}

		private static void AddAllInternalFields<TModelType>(EntityTypeBuilder<TModelType> entity) 
			where TModelType : class
		{
			string[] internalFieldNames = (string[])typeof(TModelType)
				.GetField("INTERNAL_FIELD_NAMES", BindingFlags.Public | BindingFlags.Static)
				.GetValue(null);

			foreach (string name in internalFieldNames)
			{
				PropertyInfo info = typeof(TModelType).GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
				if(info.Type().HasAttribute<OwnedAttribute>())
				{
					entity.OwnsOne(info.Type(), name);
				}
				else
					entity.Property(name);
			}
		}

		public DataBaseClientFilesDatabaseContext()
		{
			
		}
	}
}
