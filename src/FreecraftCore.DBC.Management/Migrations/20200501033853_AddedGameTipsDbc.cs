using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedGameTipsDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameTips",
                columns: table => new
                {
                    GameTipId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tip_enUS = table.Column<string>(nullable: true),
                    Tip_koKR = table.Column<string>(nullable: true),
                    Tip_frFR = table.Column<string>(nullable: true),
                    Tip_deDE = table.Column<string>(nullable: true),
                    Tip_enCN = table.Column<string>(nullable: true),
                    Tip_enTW = table.Column<string>(nullable: true),
                    Tip_esES = table.Column<string>(nullable: true),
                    Tip_esMX = table.Column<string>(nullable: true),
                    Tip_ruRU = table.Column<string>(nullable: true),
                    Tip_ptPT = table.Column<string>(nullable: true),
                    Tip_itIT = table.Column<string>(nullable: true),
                    Tip_Flags = table.Column<uint>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTips", x => x.GameTipId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTips");
        }
    }
}
