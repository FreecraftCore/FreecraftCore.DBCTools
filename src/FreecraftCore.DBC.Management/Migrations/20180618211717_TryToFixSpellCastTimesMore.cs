using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class TryToFixSpellCastTimesMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CastTimePerLevel",
                table: "SpellCastTimes",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "CastTimePerLevel",
                table: "SpellCastTimes",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
