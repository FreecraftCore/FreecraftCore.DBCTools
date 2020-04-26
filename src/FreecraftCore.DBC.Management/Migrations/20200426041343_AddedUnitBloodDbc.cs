using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedUnitBloodDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitBlood",
                columns: table => new
                {
                    UnitBloodId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BloodSpurtFrontSmall = table.Column<int>(nullable: false),
                    BloodSpurtFrontLarge = table.Column<int>(nullable: false),
                    BloodSpurtBackSmall = table.Column<int>(nullable: false),
                    BloodSpurtBackLarge = table.Column<int>(nullable: false),
                    GroundBloodFileName_One = table.Column<string>(nullable: true),
                    GroundBloodFileName_Two = table.Column<string>(nullable: true),
                    GroundBloodFileName_Three = table.Column<string>(nullable: true),
                    GroundBloodFileName_Four = table.Column<string>(nullable: true),
                    GroundBloodFileName_Five = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitBlood", x => x.UnitBloodId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitBlood");
        }
    }
}
