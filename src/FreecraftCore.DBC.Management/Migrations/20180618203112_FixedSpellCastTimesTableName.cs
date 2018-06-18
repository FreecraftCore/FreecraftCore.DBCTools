using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class FixedSpellCastTimesTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellCastTime",
                table: "SpellCastTime");

            migrationBuilder.RenameTable(
                name: "SpellCastTime",
                newName: "SpellCastTimes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellCastTimes",
                table: "SpellCastTimes",
                column: "SpellCastTimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellCastTimes",
                table: "SpellCastTimes");

            migrationBuilder.RenameTable(
                name: "SpellCastTimes",
                newName: "SpellCastTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellCastTime",
                table: "SpellCastTime",
                column: "SpellCastTimeId");
        }
    }
}
