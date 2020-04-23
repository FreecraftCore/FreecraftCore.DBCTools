using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedCameraShakesDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CameraShakes",
                columns: table => new
                {
                    CameraShakeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShakeType = table.Column<int>(nullable: false),
                    Direction = table.Column<int>(nullable: false),
                    Amplitude = table.Column<float>(nullable: false),
                    Frequency = table.Column<float>(nullable: false),
                    Duration = table.Column<float>(nullable: false),
                    Phase = table.Column<float>(nullable: false),
                    Coefficient = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraShakes", x => x.CameraShakeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CameraShakes");
        }
    }
}
