using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class NewInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemClassId = table.Column<int>(nullable: false),
                    ItemSubClassId = table.Column<int>(nullable: false),
                    SoundOverride = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    ItemDisplayId = table.Column<int>(nullable: false),
                    InventorySlotType = table.Column<int>(nullable: false),
                    SheathType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "SkillLineAbility",
                columns: table => new
                {
                    SkillLineAbilityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SkillId = table.Column<uint>(nullable: false),
                    SpellId = table.Column<uint>(nullable: false),
                    Racemask = table.Column<uint>(nullable: false),
                    Classmask = table.Column<uint>(nullable: false),
                    RacemaskNot = table.Column<uint>(nullable: false),
                    ClassmaskNot = table.Column<uint>(nullable: false),
                    RequiredSkillValue = table.Column<uint>(nullable: false),
                    ForwardSpellid = table.Column<uint>(nullable: false),
                    SkillAquireMethod = table.Column<uint>(nullable: false),
                    MaxValue = table.Column<uint>(nullable: false),
                    MinValue = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLineAbility", x => x.SkillLineAbilityId);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    SpellId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<uint>(nullable: false),
                    Dispel = table.Column<uint>(nullable: false),
                    Mechanic = table.Column<int>(nullable: false),
                    Attributes = table.Column<uint>(nullable: false),
                    AttributesEx = table.Column<uint>(nullable: false),
                    AttributesEx2 = table.Column<uint>(nullable: false),
                    AttributesEx3 = table.Column<uint>(nullable: false),
                    AttributesEx4 = table.Column<uint>(nullable: false),
                    AttributesEx5 = table.Column<uint>(nullable: false),
                    AttributesEx6 = table.Column<uint>(nullable: false),
                    AttributesEx7 = table.Column<uint>(nullable: false),
                    Stances = table.Column<ulong>(nullable: false),
                    StancesNot = table.Column<ulong>(nullable: false),
                    Targets = table.Column<uint>(nullable: false),
                    TargetCreatureType = table.Column<int>(nullable: false),
                    RequiresSpellFocus = table.Column<uint>(nullable: false),
                    FacingCasterFlags = table.Column<uint>(nullable: false),
                    CasterAuraState = table.Column<int>(nullable: false),
                    TargetAuraState = table.Column<int>(nullable: false),
                    CasterAuraStateNot = table.Column<int>(nullable: false),
                    TargetAuraStateNot = table.Column<int>(nullable: false),
                    CasterAuraSpell = table.Column<uint>(nullable: false),
                    TargetAuraSpell = table.Column<uint>(nullable: false),
                    ExcludeCasterAuraSpell = table.Column<uint>(nullable: false),
                    ExcludeTargetAuraSpell = table.Column<uint>(nullable: false),
                    CastingTimeIndex = table.Column<uint>(nullable: false),
                    RecoveryTime = table.Column<uint>(nullable: false),
                    CategoryRecoveryTime = table.Column<uint>(nullable: false),
                    InterruptFlags = table.Column<uint>(nullable: false),
                    AuraInterruptFlags = table.Column<uint>(nullable: false),
                    ChannelInterruptFlags = table.Column<uint>(nullable: false),
                    ProcFlags = table.Column<int>(nullable: false),
                    ProcChance = table.Column<uint>(nullable: false),
                    ProcCharges = table.Column<uint>(nullable: false),
                    MaxLevel = table.Column<uint>(nullable: false),
                    BaseLevel = table.Column<uint>(nullable: false),
                    SpellLevel = table.Column<uint>(nullable: false),
                    DurationIndex = table.Column<uint>(nullable: false),
                    PowerType = table.Column<uint>(nullable: false),
                    ManaCost = table.Column<uint>(nullable: false),
                    ManaCostPerlevel = table.Column<uint>(nullable: false),
                    ManaPerSecond = table.Column<uint>(nullable: false),
                    ManaPerSecondPerLevel = table.Column<uint>(nullable: false),
                    RangeIndex = table.Column<uint>(nullable: false),
                    Speed = table.Column<float>(nullable: false),
                    ModalNextSpell = table.Column<uint>(nullable: false),
                    StackAmount = table.Column<uint>(nullable: false),
                    ReagentsRequired_Totem_One = table.Column<uint>(nullable: false),
                    ReagentsRequired_Totem_Two = table.Column<uint>(nullable: false),
                    ReagentsRequired_ReagentId_One = table.Column<int>(nullable: false),
                    ReagentsRequired_ReagentId_Two = table.Column<int>(nullable: false),
                    ReagentsRequired_ReagentId_Three = table.Column<int>(nullable: false),
                    ReagentsRequired_ReagentId_Four = table.Column<int>(nullable: false),
                    ReagentsRequired_ReagentId_Five = table.Column<int>(nullable: false),
                    ReagentsRequired_ReagentId_Six = table.Column<int>(nullable: false),
                    ReagentsRequired_ReagentId_Seven = table.Column<int>(nullable: false),
                    ReagentsRequired_ReagentId_Eight = table.Column<int>(nullable: false),
                    ReagentsRequired_ReagentCount_One = table.Column<uint>(nullable: false),
                    ReagentsRequired_ReagentCount_Two = table.Column<uint>(nullable: false),
                    ReagentsRequired_ReagentCount_Three = table.Column<uint>(nullable: false),
                    ReagentsRequired_ReagentCount_Four = table.Column<uint>(nullable: false),
                    ReagentsRequired_ReagentCount_Five = table.Column<uint>(nullable: false),
                    ReagentsRequired_ReagentCount_Six = table.Column<uint>(nullable: false),
                    ReagentsRequired_ReagentCount_Seven = table.Column<uint>(nullable: false),
                    ReagentsRequired_ReagentCount_Eight = table.Column<uint>(nullable: false),
                    EquippedItemClass = table.Column<int>(nullable: false),
                    EquippedItemSubClassMask = table.Column<int>(nullable: false),
                    EquippedItemInventoryTypeMask = table.Column<int>(nullable: false),
                    SpellEffectInformation_Effect_Effect1 = table.Column<int>(nullable: false),
                    SpellEffectInformation_Effect_Effect2 = table.Column<int>(nullable: false),
                    SpellEffectInformation_Effect_Effect3 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectDieSides_Effect1 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectDieSides_Effect2 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectDieSides_Effect3 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectRealPointsPerLevel_Effect1 = table.Column<float>(nullable: false),
                    SpellEffectInformation_EffectRealPointsPerLevel_Effect2 = table.Column<float>(nullable: false),
                    SpellEffectInformation_EffectRealPointsPerLevel_Effect3 = table.Column<float>(nullable: false),
                    SpellEffectInformation_EffectBasePoints_Effect1 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectBasePoints_Effect2 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectBasePoints_Effect3 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectMechanic_Effect1 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectMechanic_Effect2 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectMechanic_Effect3 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectImplicitTargetA_Effect1 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectImplicitTargetA_Effect2 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectImplicitTargetA_Effect3 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectImplicitTargetB_Effect1 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectImplicitTargetB_Effect2 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectImplicitTargetB_Effect3 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectRadiusIndex_Effect1 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectRadiusIndex_Effect2 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectRadiusIndex_Effect3 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectApplyAuraName_Effect1 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectApplyAuraName_Effect2 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectApplyAuraName_Effect3 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectAmplitude_Effect1 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectAmplitude_Effect2 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectAmplitude_Effect3 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectMultipleValue_Effect1 = table.Column<float>(nullable: false),
                    SpellEffectInformation_EffectMultipleValue_Effect2 = table.Column<float>(nullable: false),
                    SpellEffectInformation_EffectMultipleValue_Effect3 = table.Column<float>(nullable: false),
                    SpellEffectInformation_EffectChainTarget_Effect1 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectChainTarget_Effect2 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectChainTarget_Effect3 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectItemType_Effect1 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectItemType_Effect2 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectItemType_Effect3 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectMiscValue_Effect1 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectMiscValue_Effect2 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectMiscValue_Effect3 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectMiscValueB_Effect1 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectMiscValueB_Effect2 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectMiscValueB_Effect3 = table.Column<int>(nullable: false),
                    SpellEffectInformation_EffectTriggerSpell_Effect1 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectTriggerSpell_Effect2 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectTriggerSpell_Effect3 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectPointsPerComboPoint_Effect1 = table.Column<float>(nullable: false),
                    SpellEffectInformation_EffectPointsPerComboPoint_Effect2 = table.Column<float>(nullable: false),
                    SpellEffectInformation_EffectPointsPerComboPoint_Effect3 = table.Column<float>(nullable: false),
                    SpellEffectInformation_EffectSpellClassMaskA_Effect1 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectSpellClassMaskA_Effect2 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectSpellClassMaskA_Effect3 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectSpellClassMaskB_Effect1 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectSpellClassMaskB_Effect2 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectSpellClassMaskB_Effect3 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectSpellClassMaskC_Effect1 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectSpellClassMaskC_Effect2 = table.Column<uint>(nullable: false),
                    SpellEffectInformation_EffectSpellClassMaskC_Effect3 = table.Column<uint>(nullable: false),
                    SpellVisual_One = table.Column<uint>(nullable: false),
                    SpellVisual_Two = table.Column<uint>(nullable: false),
                    SpellIconID = table.Column<uint>(nullable: false),
                    ActiveIconID = table.Column<uint>(nullable: false),
                    SpellPriority = table.Column<uint>(nullable: false),
                    SpellName_enUS = table.Column<string>(nullable: true),
                    SpellName_koKR = table.Column<string>(nullable: true),
                    SpellName_frFR = table.Column<string>(nullable: true),
                    SpellName_deDE = table.Column<string>(nullable: true),
                    SpellName_enCN = table.Column<string>(nullable: true),
                    SpellName_enTW = table.Column<string>(nullable: true),
                    SpellName_esES = table.Column<string>(nullable: true),
                    SpellName_esMX = table.Column<string>(nullable: true),
                    SpellName_ruRU = table.Column<string>(nullable: true),
                    SpellName_ptPT = table.Column<string>(nullable: true),
                    SpellName_itIT = table.Column<string>(nullable: true),
                    SpellName_Flags = table.Column<uint>(nullable: false),
                    Rank_enUS = table.Column<string>(nullable: true),
                    Rank_koKR = table.Column<string>(nullable: true),
                    Rank_frFR = table.Column<string>(nullable: true),
                    Rank_deDE = table.Column<string>(nullable: true),
                    Rank_enCN = table.Column<string>(nullable: true),
                    Rank_enTW = table.Column<string>(nullable: true),
                    Rank_esES = table.Column<string>(nullable: true),
                    Rank_esMX = table.Column<string>(nullable: true),
                    Rank_ruRU = table.Column<string>(nullable: true),
                    Rank_ptPT = table.Column<string>(nullable: true),
                    Rank_itIT = table.Column<string>(nullable: true),
                    Rank_Flags = table.Column<uint>(nullable: false),
                    Description_enUS = table.Column<string>(nullable: true),
                    Description_koKR = table.Column<string>(nullable: true),
                    Description_frFR = table.Column<string>(nullable: true),
                    Description_deDE = table.Column<string>(nullable: true),
                    Description_enCN = table.Column<string>(nullable: true),
                    Description_enTW = table.Column<string>(nullable: true),
                    Description_esES = table.Column<string>(nullable: true),
                    Description_esMX = table.Column<string>(nullable: true),
                    Description_ruRU = table.Column<string>(nullable: true),
                    Description_ptPT = table.Column<string>(nullable: true),
                    Description_itIT = table.Column<string>(nullable: true),
                    Description_Flags = table.Column<uint>(nullable: false),
                    ToolTip_enUS = table.Column<string>(nullable: true),
                    ToolTip_koKR = table.Column<string>(nullable: true),
                    ToolTip_frFR = table.Column<string>(nullable: true),
                    ToolTip_deDE = table.Column<string>(nullable: true),
                    ToolTip_enCN = table.Column<string>(nullable: true),
                    ToolTip_enTW = table.Column<string>(nullable: true),
                    ToolTip_esES = table.Column<string>(nullable: true),
                    ToolTip_esMX = table.Column<string>(nullable: true),
                    ToolTip_ruRU = table.Column<string>(nullable: true),
                    ToolTip_ptPT = table.Column<string>(nullable: true),
                    ToolTip_itIT = table.Column<string>(nullable: true),
                    ToolTip_Flags = table.Column<uint>(nullable: false),
                    ManaCostPercentage = table.Column<uint>(nullable: false),
                    StartRecoveryCategory = table.Column<uint>(nullable: false),
                    StartRecoveryTime = table.Column<uint>(nullable: false),
                    MaxTargetLevel = table.Column<uint>(nullable: false),
                    SpellFamilyName = table.Column<int>(nullable: false),
                    SpellFamilyFlags_One = table.Column<uint>(nullable: false),
                    SpellFamilyFlags_Two = table.Column<uint>(nullable: false),
                    SpellFamilyFlags_Three = table.Column<uint>(nullable: false),
                    MaxAffectedTargets = table.Column<uint>(nullable: false),
                    DmgClass = table.Column<int>(nullable: false),
                    PreventionType = table.Column<int>(nullable: false),
                    StanceBarOrder = table.Column<uint>(nullable: false),
                    DmgMultiplier_Effect1 = table.Column<float>(nullable: false),
                    DmgMultiplier_Effect2 = table.Column<float>(nullable: false),
                    DmgMultiplier_Effect3 = table.Column<float>(nullable: false),
                    MinFactionId = table.Column<uint>(nullable: false),
                    MinReputation = table.Column<uint>(nullable: false),
                    RequiredAuraVision = table.Column<uint>(nullable: false),
                    TotemCategory_One = table.Column<uint>(nullable: false),
                    TotemCategory_Two = table.Column<uint>(nullable: false),
                    AreaGroupId = table.Column<int>(nullable: false),
                    SchoolMask = table.Column<int>(nullable: false),
                    RuneCostID = table.Column<uint>(nullable: false),
                    SpellMissileID = table.Column<uint>(nullable: false),
                    PowerDisplayId = table.Column<uint>(nullable: false),
                    DamageCoeficient_Effect1 = table.Column<float>(nullable: false),
                    DamageCoeficient_Effect2 = table.Column<float>(nullable: false),
                    DamageCoeficient_Effect3 = table.Column<float>(nullable: false),
                    SpellDescriptionVariableID = table.Column<uint>(nullable: false),
                    SpellDifficultyId = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.SpellId);
                });

            migrationBuilder.CreateTable(
                name: "SpellCastTimes",
                columns: table => new
                {
                    SpellCastTimeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CastTime = table.Column<int>(nullable: false),
                    CastTimePerLevel = table.Column<float>(nullable: false),
                    MinCastTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellCastTimes", x => x.SpellCastTimeId);
                });

            migrationBuilder.CreateTable(
                name: "SpellDifficulty",
                columns: table => new
                {
                    SpellDifficultyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Normal10manSpellId = table.Column<int>(nullable: false),
                    Normal25manSpellId = table.Column<int>(nullable: false),
                    Heroic10manSpellId = table.Column<int>(nullable: false),
                    Heroic25manSpellId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDifficulty", x => x.SpellDifficultyId);
                });

            migrationBuilder.CreateTable(
                name: "SpellDuration",
                columns: table => new
                {
                    SpellDurationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<uint>(nullable: false),
                    DurationPerLevel = table.Column<uint>(nullable: false),
                    MaxDuration = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDuration", x => x.SpellDurationId);
                });

            migrationBuilder.CreateTable(
                name: "SpellRadius",
                columns: table => new
                {
                    SpellRadiusId = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Radius = table.Column<float>(nullable: false),
                    Zero = table.Column<int>(nullable: false),
                    Radius2 = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellRadius", x => x.SpellRadiusId);
                });

            migrationBuilder.CreateTable(
                name: "SpellRange",
                columns: table => new
                {
                    SpellRangeId = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MinRange = table.Column<float>(nullable: false),
                    MinRangeFriendly = table.Column<float>(nullable: false),
                    MaxRange = table.Column<float>(nullable: false),
                    MaxRangeFriendly = table.Column<float>(nullable: false),
                    Field5 = table.Column<uint>(nullable: false),
                    Description1_enUS = table.Column<string>(nullable: true),
                    Description1_koKR = table.Column<string>(nullable: true),
                    Description1_frFR = table.Column<string>(nullable: true),
                    Description1_deDE = table.Column<string>(nullable: true),
                    Description1_enCN = table.Column<string>(nullable: true),
                    Description1_enTW = table.Column<string>(nullable: true),
                    Description1_esES = table.Column<string>(nullable: true),
                    Description1_esMX = table.Column<string>(nullable: true),
                    Description1_ruRU = table.Column<string>(nullable: true),
                    Description1_ptPT = table.Column<string>(nullable: true),
                    Description1_itIT = table.Column<string>(nullable: true),
                    Description1_Flags = table.Column<uint>(nullable: false),
                    Description2_enUS = table.Column<string>(nullable: true),
                    Description2_koKR = table.Column<string>(nullable: true),
                    Description2_frFR = table.Column<string>(nullable: true),
                    Description2_deDE = table.Column<string>(nullable: true),
                    Description2_enCN = table.Column<string>(nullable: true),
                    Description2_enTW = table.Column<string>(nullable: true),
                    Description2_esES = table.Column<string>(nullable: true),
                    Description2_esMX = table.Column<string>(nullable: true),
                    Description2_ruRU = table.Column<string>(nullable: true),
                    Description2_ptPT = table.Column<string>(nullable: true),
                    Description2_itIT = table.Column<string>(nullable: true),
                    Description2_Flags = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellRange", x => x.SpellRangeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "SkillLineAbility");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "SpellCastTimes");

            migrationBuilder.DropTable(
                name: "SpellDifficulty");

            migrationBuilder.DropTable(
                name: "SpellDuration");

            migrationBuilder.DropTable(
                name: "SpellRadius");

            migrationBuilder.DropTable(
                name: "SpellRange");
        }
    }
}
