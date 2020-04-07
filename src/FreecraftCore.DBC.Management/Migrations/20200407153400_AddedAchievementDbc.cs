using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedAchievementDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    AchievementId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Faction = table.Column<int>(nullable: false),
                    MapId = table.Column<int>(nullable: false),
                    SupersedesId = table.Column<int>(nullable: false),
                    Title_enUS = table.Column<string>(nullable: true),
                    Title_koKR = table.Column<string>(nullable: true),
                    Title_frFR = table.Column<string>(nullable: true),
                    Title_deDE = table.Column<string>(nullable: true),
                    Title_enCN = table.Column<string>(nullable: true),
                    Title_enTW = table.Column<string>(nullable: true),
                    Title_esES = table.Column<string>(nullable: true),
                    Title_esMX = table.Column<string>(nullable: true),
                    Title_ruRU = table.Column<string>(nullable: true),
                    Title_ptPT = table.Column<string>(nullable: true),
                    Title_itIT = table.Column<string>(nullable: true),
                    Title_Flags = table.Column<uint>(nullable: true),
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
                    CategoryID = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    UIOrder = table.Column<int>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    IconId = table.Column<int>(nullable: false),
                    Reward_enUS = table.Column<string>(nullable: true),
                    Reward_koKR = table.Column<string>(nullable: true),
                    Reward_frFR = table.Column<string>(nullable: true),
                    Reward_deDE = table.Column<string>(nullable: true),
                    Reward_enCN = table.Column<string>(nullable: true),
                    Reward_enTW = table.Column<string>(nullable: true),
                    Reward_esES = table.Column<string>(nullable: true),
                    Reward_esMX = table.Column<string>(nullable: true),
                    Reward_ruRU = table.Column<string>(nullable: true),
                    Reward_ptPT = table.Column<string>(nullable: true),
                    Reward_itIT = table.Column<string>(nullable: true),
                    Reward_Flags = table.Column<uint>(nullable: true),
                    MinimumCriteriaCount = table.Column<int>(nullable: false),
                    SharesCriteriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.AchievementId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");
        }
    }
}
