using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedAreaTriggerDbcModelWithAttemptedOwneVectorsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "CharacterPoints_X",
                table: "SkillLineAbility",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "CharacterPoints_Y",
                table: "SkillLineAbility",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<float>(
                name: "Position_X",
                table: "AreaTrigger",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Position_Y",
                table: "AreaTrigger",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Position_Z",
                table: "AreaTrigger",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "UnalignedBoxDimension_X",
                table: "AreaTrigger",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "UnalignedBoxDimension_Y",
                table: "AreaTrigger",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "UnalignedBoxDimension_Z",
                table: "AreaTrigger",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterPoints_X",
                table: "SkillLineAbility");

            migrationBuilder.DropColumn(
                name: "CharacterPoints_Y",
                table: "SkillLineAbility");

            migrationBuilder.DropColumn(
                name: "Position_X",
                table: "AreaTrigger");

            migrationBuilder.DropColumn(
                name: "Position_Y",
                table: "AreaTrigger");

            migrationBuilder.DropColumn(
                name: "Position_Z",
                table: "AreaTrigger");

            migrationBuilder.DropColumn(
                name: "UnalignedBoxDimension_X",
                table: "AreaTrigger");

            migrationBuilder.DropColumn(
                name: "UnalignedBoxDimension_Y",
                table: "AreaTrigger");

            migrationBuilder.DropColumn(
                name: "UnalignedBoxDimension_Z",
                table: "AreaTrigger");
        }
    }
}
