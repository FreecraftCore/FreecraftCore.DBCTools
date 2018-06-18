using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class FixSpellCastTimesFieldTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<uint>(
                name: "MinCastTime",
                table: "SpellCastTimes",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<uint>(
                name: "CastTime",
                table: "SpellCastTimes",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinCastTime",
                table: "SpellCastTimes",
                nullable: false,
                oldClrType: typeof(uint));

            migrationBuilder.AlterColumn<int>(
                name: "CastTime",
                table: "SpellCastTimes",
                nullable: false,
                oldClrType: typeof(uint));
        }
    }
}
