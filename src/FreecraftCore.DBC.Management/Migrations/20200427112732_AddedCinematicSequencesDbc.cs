using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedCinematicSequencesDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinematicSequences",
                columns: table => new
                {
                    SequenceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SoundId = table.Column<int>(nullable: false),
                    CameraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinematicSequences", x => x.SequenceId);
                    table.ForeignKey(
                        name: "FK_CinematicSequences_CinematicCamera_CameraId",
                        column: x => x.CameraId,
                        principalTable: "CinematicCamera",
                        principalColumn: "CinematicCameraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinematicSequences_CameraId",
                table: "CinematicSequences",
                column: "CameraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinematicSequences");
        }
    }
}
