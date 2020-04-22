using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedFactionDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faction",
                columns: table => new
                {
                    FactionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReputationIndex = table.Column<int>(nullable: false),
                    Rate_RaceMask_X = table.Column<int>(nullable: true),
                    Rate_RaceMask_Y = table.Column<int>(nullable: true),
                    Rate_RaceMask_Z = table.Column<int>(nullable: true),
                    Rate_RaceMask_W = table.Column<int>(nullable: true),
                    Rate_ClassMask_X = table.Column<int>(nullable: true),
                    Rate_ClassMask_Y = table.Column<int>(nullable: true),
                    Rate_ClassMask_Z = table.Column<int>(nullable: true),
                    Rate_ClassMask_W = table.Column<int>(nullable: true),
                    Rate_BaseReputation_X = table.Column<int>(nullable: true),
                    Rate_BaseReputation_Y = table.Column<int>(nullable: true),
                    Rate_BaseReputation_Z = table.Column<int>(nullable: true),
                    Rate_BaseReputation_W = table.Column<int>(nullable: true),
                    Rate_FactionFlag_X = table.Column<int>(nullable: true),
                    Rate_FactionFlag_Y = table.Column<int>(nullable: true),
                    Rate_FactionFlag_Z = table.Column<int>(nullable: true),
                    Rate_FactionFlag_W = table.Column<int>(nullable: true),
                    ParentFactionId = table.Column<int>(nullable: false),
                    ParentFactionSpillInMod = table.Column<int>(nullable: false),
                    ParentFactionSpillOutMod = table.Column<int>(nullable: false),
                    ParentFactionSpillInMaxRank = table.Column<int>(nullable: false),
                    ParentFactionSpillOutMaxRank = table.Column<int>(nullable: false),
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
                    Description_enUS = table.Column<string>(nullable: true),
                    Description_koKR = table.Column<string>(nullable: true),
                    Description_frFR = table.Column<string>(nullable: true),
                    Description_deDE = table.Column<string>(nullable: true),
                    Description_enCN = table.Column<string>(nullable: true),
                    Description_enTW = table.Column<string>(nullable: true),
                    Description_esES = table.Column<string>(nullable: true),
                    Description_esMX = table.Column<string>(nullable: true),
                    Description_ruRU = table.Column<string>(nullable: true),
                    Description_ptPT = table.Column<string>(nullable: true),
                    Description_itIT = table.Column<string>(nullable: true),
                    Description_Flags = table.Column<uint>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faction", x => x.FactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faction");
        }
    }
}
