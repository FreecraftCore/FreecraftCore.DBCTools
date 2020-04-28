using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedChrRacesDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChrRaces",
                columns: table => new
                {
                    RaceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Flags = table.Column<int>(nullable: false),
                    FactionTemplateId = table.Column<int>(nullable: false),
                    ExplorationSoundId = table.Column<int>(nullable: false),
                    DefaultMaleDisplayInfoId = table.Column<int>(nullable: false),
                    DefaultFemaleDisplayInfoId = table.Column<int>(nullable: false),
                    RacePrefix = table.Column<string>(nullable: true),
                    BaseLanguageId = table.Column<int>(nullable: false),
                    CreatureTypeId = table.Column<int>(nullable: false),
                    ResSicknessSpellId = table.Column<int>(nullable: false),
                    SplashSoundId = table.Column<int>(nullable: false),
                    ClientFileString = table.Column<string>(nullable: true),
                    CinematicSequenceId = table.Column<int>(nullable: false),
                    Alliance = table.Column<int>(nullable: false),
                    Name_enUS = table.Column<string>(nullable: true),
                    Name_koKR = table.Column<string>(nullable: true),
                    Name_frFR = table.Column<string>(nullable: true),
                    Name_deDE = table.Column<string>(nullable: true),
                    Name_enCN = table.Column<string>(nullable: true),
                    Name_enTW = table.Column<string>(nullable: true),
                    Name_esES = table.Column<string>(nullable: true),
                    Name_esMX = table.Column<string>(nullable: true),
                    Name_ruRU = table.Column<string>(nullable: true),
                    Name_ptPT = table.Column<string>(nullable: true),
                    Name_itIT = table.Column<string>(nullable: true),
                    Name_Flags = table.Column<uint>(nullable: true),
                    FemaleName_enUS = table.Column<string>(nullable: true),
                    FemaleName_koKR = table.Column<string>(nullable: true),
                    FemaleName_frFR = table.Column<string>(nullable: true),
                    FemaleName_deDE = table.Column<string>(nullable: true),
                    FemaleName_enCN = table.Column<string>(nullable: true),
                    FemaleName_enTW = table.Column<string>(nullable: true),
                    FemaleName_esES = table.Column<string>(nullable: true),
                    FemaleName_esMX = table.Column<string>(nullable: true),
                    FemaleName_ruRU = table.Column<string>(nullable: true),
                    FemaleName_ptPT = table.Column<string>(nullable: true),
                    FemaleName_itIT = table.Column<string>(nullable: true),
                    FemaleName_Flags = table.Column<uint>(nullable: true),
                    MaleName_enUS = table.Column<string>(nullable: true),
                    MaleName_koKR = table.Column<string>(nullable: true),
                    MaleName_frFR = table.Column<string>(nullable: true),
                    MaleName_deDE = table.Column<string>(nullable: true),
                    MaleName_enCN = table.Column<string>(nullable: true),
                    MaleName_enTW = table.Column<string>(nullable: true),
                    MaleName_esES = table.Column<string>(nullable: true),
                    MaleName_esMX = table.Column<string>(nullable: true),
                    MaleName_ruRU = table.Column<string>(nullable: true),
                    MaleName_ptPT = table.Column<string>(nullable: true),
                    MaleName_itIT = table.Column<string>(nullable: true),
                    MaleName_Flags = table.Column<uint>(nullable: true),
                    FacialCustomizationInternalName_Internal = table.Column<string>(nullable: true),
                    FacialCustomizationInternalName = table.Column<string>(nullable: true),
                    HairCustomizationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChrRaces", x => x.RaceId);
                    table.ForeignKey(
                        name: "FK_ChrRaces_Languages_BaseLanguageId",
                        column: x => x.BaseLanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChrRaces_CreatureType_CreatureTypeId",
                        column: x => x.CreatureTypeId,
                        principalTable: "CreatureType",
                        principalColumn: "CreatureTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChrRaces_CreatureDisplayInfo_DefaultFemaleDisplayInfoId",
                        column: x => x.DefaultFemaleDisplayInfoId,
                        principalTable: "CreatureDisplayInfo",
                        principalColumn: "CreatureDisplayInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChrRaces_CreatureDisplayInfo_DefaultMaleDisplayInfoId",
                        column: x => x.DefaultMaleDisplayInfoId,
                        principalTable: "CreatureDisplayInfo",
                        principalColumn: "CreatureDisplayInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChrRaces_FactionTemplate_FactionTemplateId",
                        column: x => x.FactionTemplateId,
                        principalTable: "FactionTemplate",
                        principalColumn: "FactionTemplateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChrRaces_Spell_ResSicknessSpellId",
                        column: x => x.ResSicknessSpellId,
                        principalTable: "Spell",
                        principalColumn: "SpellId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChrRaces_SoundEntries_SplashSoundId",
                        column: x => x.SplashSoundId,
                        principalTable: "SoundEntries",
                        principalColumn: "SoundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChrRaces_BaseLanguageId",
                table: "ChrRaces",
                column: "BaseLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ChrRaces_CreatureTypeId",
                table: "ChrRaces",
                column: "CreatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChrRaces_DefaultFemaleDisplayInfoId",
                table: "ChrRaces",
                column: "DefaultFemaleDisplayInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChrRaces_DefaultMaleDisplayInfoId",
                table: "ChrRaces",
                column: "DefaultMaleDisplayInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChrRaces_FactionTemplateId",
                table: "ChrRaces",
                column: "FactionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ChrRaces_ResSicknessSpellId",
                table: "ChrRaces",
                column: "ResSicknessSpellId");

            migrationBuilder.CreateIndex(
                name: "IX_ChrRaces_SplashSoundId",
                table: "ChrRaces",
                column: "SplashSoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChrRaces");
        }
    }
}
