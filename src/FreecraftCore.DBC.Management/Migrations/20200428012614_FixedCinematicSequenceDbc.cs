using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class FixedCinematicSequenceDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnusedCameraId_One",
                table: "CinematicSequences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnusedCameraId_Two",
                table: "CinematicSequences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnusedCameraId_Three",
                table: "CinematicSequences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnusedCameraId_Four",
                table: "CinematicSequences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnusedCameraId_Five",
                table: "CinematicSequences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnusedCameraId_Six",
                table: "CinematicSequences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnusedCameraId_Seven",
                table: "CinematicSequences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnusedCameraId_Five",
                table: "CinematicSequences");

            migrationBuilder.DropColumn(
                name: "UnusedCameraId_Four",
                table: "CinematicSequences");

            migrationBuilder.DropColumn(
                name: "UnusedCameraId_One",
                table: "CinematicSequences");

            migrationBuilder.DropColumn(
                name: "UnusedCameraId_Seven",
                table: "CinematicSequences");

            migrationBuilder.DropColumn(
                name: "UnusedCameraId_Six",
                table: "CinematicSequences");

            migrationBuilder.DropColumn(
                name: "UnusedCameraId_Three",
                table: "CinematicSequences");

            migrationBuilder.DropColumn(
                name: "UnusedCameraId_Two",
                table: "CinematicSequences");
        }
    }
}
