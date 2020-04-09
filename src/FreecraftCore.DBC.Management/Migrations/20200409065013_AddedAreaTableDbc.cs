using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedAreaTableDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaTable",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MapId = table.Column<int>(nullable: false),
                    ParentAreaId = table.Column<int>(nullable: false),
                    AreaBit = table.Column<int>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    SoundProviderPreference = table.Column<int>(nullable: false),
                    SoundProviderPreferenceUnderwater = table.Column<int>(nullable: false),
                    AmbienceId = table.Column<int>(nullable: false),
                    ZoneMusicId = table.Column<int>(nullable: false),
                    IntroSoundId = table.Column<int>(nullable: false),
                    AreaExplorationLevel = table.Column<int>(nullable: false),
                    AreaName_enUS = table.Column<string>(nullable: true),
                    AreaName_koKR = table.Column<string>(nullable: true),
                    AreaName_frFR = table.Column<string>(nullable: true),
                    AreaName_deDE = table.Column<string>(nullable: true),
                    AreaName_enCN = table.Column<string>(nullable: true),
                    AreaName_enTW = table.Column<string>(nullable: true),
                    AreaName_esES = table.Column<string>(nullable: true),
                    AreaName_esMX = table.Column<string>(nullable: true),
                    AreaName_ruRU = table.Column<string>(nullable: true),
                    AreaName_ptPT = table.Column<string>(nullable: true),
                    AreaName_itIT = table.Column<string>(nullable: true),
                    AreaName_Flags = table.Column<uint>(nullable: true),
                    FactionTeamMask = table.Column<int>(nullable: false),
                    LiquidTypeID_X = table.Column<int>(nullable: true),
                    LiquidTypeID_Y = table.Column<int>(nullable: true),
                    LiquidTypeID_Z = table.Column<int>(nullable: true),
                    LiquidTypeID_W = table.Column<int>(nullable: true),
                    MinimumElevation = table.Column<float>(nullable: false),
                    AmbientMultiplier = table.Column<float>(nullable: false),
                    LightId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTable", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_AreaTable_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "MapId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaTable_AreaBit",
                table: "AreaTable",
                column: "AreaBit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AreaTable_MapId",
                table: "AreaTable",
                column: "MapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaTable");
        }
    }
}
