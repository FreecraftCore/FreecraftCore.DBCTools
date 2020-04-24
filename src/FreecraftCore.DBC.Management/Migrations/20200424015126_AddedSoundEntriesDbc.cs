using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedSoundEntriesDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoundEntries",
                columns: table => new
                {
                    SoundId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SoundType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    File_One = table.Column<string>(nullable: true),
                    File_Two = table.Column<string>(nullable: true),
                    File_Three = table.Column<string>(nullable: true),
                    File_Four = table.Column<string>(nullable: true),
                    File_Five = table.Column<string>(nullable: true),
                    File_Six = table.Column<string>(nullable: true),
                    File_Seven = table.Column<string>(nullable: true),
                    File_Eight = table.Column<string>(nullable: true),
                    File_Nine = table.Column<string>(nullable: true),
                    File_Ten = table.Column<string>(nullable: true),
                    Frequency_One = table.Column<int>(nullable: true),
                    Frequency_Two = table.Column<int>(nullable: true),
                    Frequency_Three = table.Column<int>(nullable: true),
                    Frequency_Four = table.Column<int>(nullable: true),
                    Frequency_Five = table.Column<int>(nullable: true),
                    Frequency_Six = table.Column<int>(nullable: true),
                    Frequency_Seven = table.Column<int>(nullable: true),
                    Frequency_Eight = table.Column<int>(nullable: true),
                    Frequency_Nine = table.Column<int>(nullable: true),
                    Frequency_Ten = table.Column<int>(nullable: true),
                    BaseDirectory = table.Column<string>(nullable: true),
                    Volume = table.Column<float>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    MinimumDistance = table.Column<float>(nullable: false),
                    DistanceCutoff = table.Column<float>(nullable: false),
                    EAXDefinition = table.Column<int>(nullable: false),
                    SoundEntriesAdvancedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundEntries", x => x.SoundId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoundEntries");
        }
    }
}
