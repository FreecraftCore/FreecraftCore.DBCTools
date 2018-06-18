using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedManyDBCModels : Migration
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
                name: "SpellCastTime",
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
                    table.PrimaryKey("PK_SpellCastTime", x => x.SpellCastTimeId);
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
                name: "SpellCastTime");

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
