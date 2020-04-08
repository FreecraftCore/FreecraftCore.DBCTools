using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedSpellItemEnchantDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpellItemEnchantment",
                columns: table => new
                {
                    EnchantmentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Charges = table.Column<int>(nullable: false),
                    Effects_Types_One = table.Column<int>(nullable: true),
                    Effects_Types_Two = table.Column<int>(nullable: true),
                    Effects_Types_Three = table.Column<int>(nullable: true),
                    Effects_PointsMinimum_One = table.Column<int>(nullable: true),
                    Effects_PointsMinimum_Two = table.Column<int>(nullable: true),
                    Effects_PointsMinimum_Three = table.Column<int>(nullable: true),
                    Effects_PointsMaximum_One = table.Column<int>(nullable: true),
                    Effects_PointsMaximum_Two = table.Column<int>(nullable: true),
                    Effects_PointsMaximum_Three = table.Column<int>(nullable: true),
                    Effects_SpellIds_One = table.Column<int>(nullable: true),
                    Effects_SpellIds_Two = table.Column<int>(nullable: true),
                    Effects_SpellIds_Three = table.Column<int>(nullable: true),
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
                    Description_Flags = table.Column<uint>(nullable: true),
                    ItemVisual = table.Column<int>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    GemItemId = table.Column<int>(nullable: false),
                    EnchantmentConditionId = table.Column<int>(nullable: false),
                    RequiredSkillId = table.Column<int>(nullable: false),
                    RequiredSkillValue = table.Column<int>(nullable: false),
                    RequiredLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellItemEnchantment", x => x.EnchantmentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellItemEnchantment");
        }
    }
}
