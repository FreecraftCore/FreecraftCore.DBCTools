using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedQuestInfoDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestInfo",
                columns: table => new
                {
                    QuestInfoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_enUS = table.Column<string>(nullable: true),
                    Name_koKR = table.Column<string>(nullable: true),
                    Name_frFR = table.Column<string>(nullable: true),
                    Name_deDE = table.Column<string>(nullable: true),
                    Name_enCN = table.Column<string>(nullable: true),
                    Name_enTW = table.Column<string>(nullable: true),
                    Name_esES = table.Column<string>(nullable: true),
                    Name_esMX = table.Column<string>(nullable: true),
                    Name_ruRU = table.Column<string>(nullable: true),
                    Name_ptPT = table.Column<string>(nullable: true),
                    Name_itIT = table.Column<string>(nullable: true),
                    Name_Flags = table.Column<uint>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestInfo", x => x.QuestInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestInfo");
        }
    }
}
