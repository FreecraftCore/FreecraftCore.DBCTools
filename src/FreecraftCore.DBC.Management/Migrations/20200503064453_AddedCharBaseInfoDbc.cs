using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedCharBaseInfoDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharBaseInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharBaseInfo", x => x.Id);
                    table.UniqueConstraint("AK_CharBaseInfo_ClassId_RaceId", x => new { x.ClassId, x.RaceId });
                });

            migrationBuilder.AddForeignKey(
                table: "CharBaseInfo",
                name: "FK_CharBaseInfo_ChrClasses_ClassId",
                column: "ClassId",
                principalTable: "ChrClasses",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                table: "CharBaseInfo",
                name: "FK_CharBaseInfo_ChrRaces_RaceId",
                column: "RaceId",
                principalTable: "ChrRaces",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharBaseInfo");
        }
    }
}
