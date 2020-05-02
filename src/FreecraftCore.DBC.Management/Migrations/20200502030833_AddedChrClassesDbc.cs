using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedChrClassesDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChrClasses",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Unk1 = table.Column<int>(nullable: false),
                    DisplayPower = table.Column<uint>(nullable: false),
                    PetNameToken = table.Column<int>(nullable: false),
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
                    FileName = table.Column<string>(nullable: true),
                    SpellClassSet = table.Column<int>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    CinematicSequenceId = table.Column<int>(nullable: false),
                    RequiredExpansion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChrClasses", x => x.ClassId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChrClasses");
        }
    }
}
