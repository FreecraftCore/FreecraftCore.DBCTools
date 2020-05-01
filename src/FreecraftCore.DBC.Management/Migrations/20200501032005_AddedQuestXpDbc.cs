using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedQuestXpDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestXP",
                columns: table => new
                {
                    Level = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DifficultyReward_One = table.Column<int>(nullable: true),
                    DifficultyReward_Two = table.Column<int>(nullable: true),
                    DifficultyReward_Three = table.Column<int>(nullable: true),
                    DifficultyReward_Four = table.Column<int>(nullable: true),
                    DifficultyReward_Five = table.Column<int>(nullable: true),
                    DifficultyReward_Six = table.Column<int>(nullable: true),
                    DifficultyReward_Seven = table.Column<int>(nullable: true),
                    DifficultyReward_Eight = table.Column<int>(nullable: true),
                    DifficultyReward_Nine = table.Column<int>(nullable: true),
                    DifficultyReward_Ten = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestXP", x => x.Level);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestXP");
        }
    }
}
