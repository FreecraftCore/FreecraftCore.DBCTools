using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedMapEntryDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    MapId = table.Column<int>(nullable: false),
                    Directory = table.Column<string>(nullable: true),
                    MapType = table.Column<int>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    PvP = table.Column<int>(nullable: false),
                    MapName_enUS = table.Column<string>(nullable: true),
                    MapName_koKR = table.Column<string>(nullable: true),
                    MapName_frFR = table.Column<string>(nullable: true),
                    MapName_deDE = table.Column<string>(nullable: true),
                    MapName_enCN = table.Column<string>(nullable: true),
                    MapName_enTW = table.Column<string>(nullable: true),
                    MapName_esES = table.Column<string>(nullable: true),
                    MapName_esMX = table.Column<string>(nullable: true),
                    MapName_ruRU = table.Column<string>(nullable: true),
                    MapName_ptPT = table.Column<string>(nullable: true),
                    MapName_itIT = table.Column<string>(nullable: true),
                    MapName_Flags = table.Column<uint>(nullable: true),
                    AreaTableId = table.Column<int>(nullable: false),
                    MapDescription0_enUS = table.Column<string>(nullable: true),
                    MapDescription0_koKR = table.Column<string>(nullable: true),
                    MapDescription0_frFR = table.Column<string>(nullable: true),
                    MapDescription0_deDE = table.Column<string>(nullable: true),
                    MapDescription0_enCN = table.Column<string>(nullable: true),
                    MapDescription0_enTW = table.Column<string>(nullable: true),
                    MapDescription0_esES = table.Column<string>(nullable: true),
                    MapDescription0_esMX = table.Column<string>(nullable: true),
                    MapDescription0_ruRU = table.Column<string>(nullable: true),
                    MapDescription0_ptPT = table.Column<string>(nullable: true),
                    MapDescription0_itIT = table.Column<string>(nullable: true),
                    MapDescription0_Flags = table.Column<uint>(nullable: true),
                    MapDescription1_enUS = table.Column<string>(nullable: true),
                    MapDescription1_koKR = table.Column<string>(nullable: true),
                    MapDescription1_frFR = table.Column<string>(nullable: true),
                    MapDescription1_deDE = table.Column<string>(nullable: true),
                    MapDescription1_enCN = table.Column<string>(nullable: true),
                    MapDescription1_enTW = table.Column<string>(nullable: true),
                    MapDescription1_esES = table.Column<string>(nullable: true),
                    MapDescription1_esMX = table.Column<string>(nullable: true),
                    MapDescription1_ruRU = table.Column<string>(nullable: true),
                    MapDescription1_ptPT = table.Column<string>(nullable: true),
                    MapDescription1_itIT = table.Column<string>(nullable: true),
                    MapDescription1_Flags = table.Column<uint>(nullable: true),
                    LoadingScreenId = table.Column<int>(nullable: false),
                    MinimapIconScale = table.Column<float>(nullable: false),
                    CorpseMapId = table.Column<int>(nullable: false),
                    Corpse_X = table.Column<int>(nullable: true),
                    Corpse_Y = table.Column<int>(nullable: true),
                    TimeOfDayOverride = table.Column<int>(nullable: false),
                    ExpansionId = table.Column<int>(nullable: false),
                    RaidOffset = table.Column<int>(nullable: false),
                    MaxPlayers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.MapId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Map");
        }
    }
}
