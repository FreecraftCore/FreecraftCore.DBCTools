using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedCinematicCameraDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinematicCamera",
                columns: table => new
                {
                    CinematicCameraId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true),
                    VoiceoverSoundId = table.Column<int>(nullable: false),
                    Endpoint_X = table.Column<float>(nullable: true),
                    Endpoint_Y = table.Column<float>(nullable: true),
                    Endpoint_Z = table.Column<float>(nullable: true),
                    Orientation = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinematicCamera", x => x.CinematicCameraId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinematicCamera");
        }
    }
}
