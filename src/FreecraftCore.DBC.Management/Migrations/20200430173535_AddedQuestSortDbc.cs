using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedQuestSortDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestSort",
                columns: table => new
                {
                    QuestSortId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName_enUS = table.Column<string>(nullable: true),
                    CategoryName_koKR = table.Column<string>(nullable: true),
                    CategoryName_frFR = table.Column<string>(nullable: true),
                    CategoryName_deDE = table.Column<string>(nullable: true),
                    CategoryName_enCN = table.Column<string>(nullable: true),
                    CategoryName_enTW = table.Column<string>(nullable: true),
                    CategoryName_esES = table.Column<string>(nullable: true),
                    CategoryName_esMX = table.Column<string>(nullable: true),
                    CategoryName_ruRU = table.Column<string>(nullable: true),
                    CategoryName_ptPT = table.Column<string>(nullable: true),
                    CategoryName_itIT = table.Column<string>(nullable: true),
                    CategoryName_Flags = table.Column<uint>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestSort", x => x.QuestSortId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestSort");
        }
    }
}
