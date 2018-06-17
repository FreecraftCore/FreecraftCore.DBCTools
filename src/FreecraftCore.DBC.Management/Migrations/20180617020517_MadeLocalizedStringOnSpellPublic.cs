using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class MadeLocalizedStringOnSpellPublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "Description_Flags",
                table: "Spell",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "Description_deDE",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_enCN",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_enTW",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_enUS",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_esES",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_esMX",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_frFR",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_itIT",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_koKR",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_ptPT",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_ruRU",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "Rank_Flags",
                table: "Spell",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "Rank_deDE",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_enCN",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_enTW",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_enUS",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_esES",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_esMX",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_frFR",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_itIT",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_koKR",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_ptPT",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank_ruRU",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "SpellName_Flags",
                table: "Spell",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_deDE",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_enCN",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_enTW",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_enUS",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_esES",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_esMX",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_frFR",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_itIT",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_koKR",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_ptPT",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellName_ruRU",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "ToolTip_Flags",
                table: "Spell",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_deDE",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_enCN",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_enTW",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_enUS",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_esES",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_esMX",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_frFR",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_itIT",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_koKR",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_ptPT",
                table: "Spell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolTip_ruRU",
                table: "Spell",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_Flags",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_deDE",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_enCN",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_enTW",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_enUS",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_esES",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_esMX",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_frFR",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_itIT",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_koKR",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_ptPT",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Description_ruRU",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_Flags",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_deDE",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_enCN",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_enTW",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_enUS",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_esES",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_esMX",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_frFR",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_itIT",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_koKR",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_ptPT",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "Rank_ruRU",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_Flags",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_deDE",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_enCN",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_enTW",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_enUS",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_esES",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_esMX",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_frFR",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_itIT",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_koKR",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_ptPT",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "SpellName_ruRU",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_Flags",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_deDE",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_enCN",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_enTW",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_enUS",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_esES",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_esMX",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_frFR",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_itIT",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_koKR",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_ptPT",
                table: "Spell");

            migrationBuilder.DropColumn(
                name: "ToolTip_ruRU",
                table: "Spell");
        }
    }
}
