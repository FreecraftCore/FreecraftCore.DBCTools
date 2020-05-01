using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedServerMessagesDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServerMessages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text_enUS = table.Column<string>(nullable: true),
                    Text_koKR = table.Column<string>(nullable: true),
                    Text_frFR = table.Column<string>(nullable: true),
                    Text_deDE = table.Column<string>(nullable: true),
                    Text_enCN = table.Column<string>(nullable: true),
                    Text_enTW = table.Column<string>(nullable: true),
                    Text_esES = table.Column<string>(nullable: true),
                    Text_esMX = table.Column<string>(nullable: true),
                    Text_ruRU = table.Column<string>(nullable: true),
                    Text_ptPT = table.Column<string>(nullable: true),
                    Text_itIT = table.Column<string>(nullable: true),
                    Text_Flags = table.Column<uint>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerMessages", x => x.MessageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerMessages");
        }
    }
}
