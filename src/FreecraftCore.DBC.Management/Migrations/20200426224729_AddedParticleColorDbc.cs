using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedParticleColorDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParticleColor",
                columns: table => new
                {
                    ParticleColorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartColor_One = table.Column<int>(nullable: true),
                    StartColor_Two = table.Column<int>(nullable: true),
                    StartColor_Three = table.Column<int>(nullable: true),
                    MidColor_One = table.Column<int>(nullable: true),
                    MidColor_Two = table.Column<int>(nullable: true),
                    MidColor_Three = table.Column<int>(nullable: true),
                    EndColor_One = table.Column<int>(nullable: true),
                    EndColor_Two = table.Column<int>(nullable: true),
                    EndColor_Three = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticleColor", x => x.ParticleColorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticleColor");
        }
    }
}
