using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedSkillLineDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillLine",
                columns: table => new
                {
                    SkillLineId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    SkillCostId = table.Column<int>(nullable: false),
                    DisplayName_enUS = table.Column<string>(nullable: true),
                    DisplayName_koKR = table.Column<string>(nullable: true),
                    DisplayName_frFR = table.Column<string>(nullable: true),
                    DisplayName_deDE = table.Column<string>(nullable: true),
                    DisplayName_enCN = table.Column<string>(nullable: true),
                    DisplayName_enTW = table.Column<string>(nullable: true),
                    DisplayName_esES = table.Column<string>(nullable: true),
                    DisplayName_esMX = table.Column<string>(nullable: true),
                    DisplayName_ruRU = table.Column<string>(nullable: true),
                    DisplayName_ptPT = table.Column<string>(nullable: true),
                    DisplayName_itIT = table.Column<string>(nullable: true),
                    DisplayName_Flags = table.Column<uint>(nullable: true),
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
                    SpellIconId = table.Column<int>(nullable: false),
                    AlternativeVerb_enUS = table.Column<string>(nullable: true),
                    AlternativeVerb_koKR = table.Column<string>(nullable: true),
                    AlternativeVerb_frFR = table.Column<string>(nullable: true),
                    AlternativeVerb_deDE = table.Column<string>(nullable: true),
                    AlternativeVerb_enCN = table.Column<string>(nullable: true),
                    AlternativeVerb_enTW = table.Column<string>(nullable: true),
                    AlternativeVerb_esES = table.Column<string>(nullable: true),
                    AlternativeVerb_esMX = table.Column<string>(nullable: true),
                    AlternativeVerb_ruRU = table.Column<string>(nullable: true),
                    AlternativeVerb_ptPT = table.Column<string>(nullable: true),
                    AlternativeVerb_itIT = table.Column<string>(nullable: true),
                    AlternativeVerb_Flags = table.Column<uint>(nullable: true),
                    CanLink = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLine", x => x.SkillLineId);
                    table.ForeignKey(
                        name: "FK_SkillLine_SkillLineCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SkillLineCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillLine_CategoryId",
                table: "SkillLine",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillLine");
        }
    }
}
