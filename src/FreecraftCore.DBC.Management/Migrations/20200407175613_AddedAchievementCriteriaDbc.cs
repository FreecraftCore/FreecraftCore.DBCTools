using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedAchievementCriteriaDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievement_Criteria",
                columns: table => new
                {
                    AchievementCriteriaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReferredAchievementId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Start_Condition = table.Column<int>(nullable: true),
                    Start_AssetId = table.Column<int>(nullable: true),
                    Fail_Condition = table.Column<int>(nullable: true),
                    Fail_AssetId = table.Column<int>(nullable: true),
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
                    Flags = table.Column<int>(nullable: false),
                    Timed_Condition = table.Column<int>(nullable: true),
                    Timed_AssetId = table.Column<int>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    UIOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement_Criteria", x => x.AchievementCriteriaId);
                    table.ForeignKey(
                        name: "FK_Achievement_Criteria_Achievement_ReferredAchievementId",
                        column: x => x.ReferredAchievementId,
                        principalTable: "Achievement",
                        principalColumn: "AchievementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_Criteria_ReferredAchievementId",
                table: "Achievement_Criteria",
                column: "ReferredAchievementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement_Criteria");
        }
    }
}
