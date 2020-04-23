using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedUnitBloodLevelsDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitBloodLevels",
                columns: table => new
                {
                    UnitBloodLevelId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ViolenceLevel_X = table.Column<int>(nullable: true),
                    ViolenceLevel_Y = table.Column<int>(nullable: true),
                    ViolenceLevel_Z = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitBloodLevels", x => x.UnitBloodLevelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitBloodLevels");
        }
    }
}
