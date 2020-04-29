using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedCharTiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharTitles",
                columns: table => new
                {
                    TitleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConditionId = table.Column<int>(nullable: false),
                    MaleName_enUS = table.Column<string>(nullable: true),
                    MaleName_koKR = table.Column<string>(nullable: true),
                    MaleName_frFR = table.Column<string>(nullable: true),
                    MaleName_deDE = table.Column<string>(nullable: true),
                    MaleName_enCN = table.Column<string>(nullable: true),
                    MaleName_enTW = table.Column<string>(nullable: true),
                    MaleName_esES = table.Column<string>(nullable: true),
                    MaleName_esMX = table.Column<string>(nullable: true),
                    MaleName_ruRU = table.Column<string>(nullable: true),
                    MaleName_ptPT = table.Column<string>(nullable: true),
                    MaleName_itIT = table.Column<string>(nullable: true),
                    MaleName_Flags = table.Column<uint>(nullable: true),
                    FemaleName_enUS = table.Column<string>(nullable: true),
                    FemaleName_koKR = table.Column<string>(nullable: true),
                    FemaleName_frFR = table.Column<string>(nullable: true),
                    FemaleName_deDE = table.Column<string>(nullable: true),
                    FemaleName_enCN = table.Column<string>(nullable: true),
                    FemaleName_enTW = table.Column<string>(nullable: true),
                    FemaleName_esES = table.Column<string>(nullable: true),
                    FemaleName_esMX = table.Column<string>(nullable: true),
                    FemaleName_ruRU = table.Column<string>(nullable: true),
                    FemaleName_ptPT = table.Column<string>(nullable: true),
                    FemaleName_itIT = table.Column<string>(nullable: true),
                    FemaleName_Flags = table.Column<uint>(nullable: true),
                    TitleBit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharTitles", x => x.TitleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharTitles_TitleBit",
                table: "CharTitles",
                column: "TitleBit",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharTitles");
        }
    }
}
