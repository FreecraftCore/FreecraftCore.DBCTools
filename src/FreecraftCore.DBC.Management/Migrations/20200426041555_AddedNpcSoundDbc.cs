using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedNpcSoundDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NPCSounds",
                columns: table => new
                {
                    NpcSoundId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GreetingsSoundId = table.Column<int>(nullable: false),
                    GoodbyeSoundId = table.Column<int>(nullable: false),
                    AnnoyedSoundId = table.Column<int>(nullable: false),
                    UnknownSoundId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCSounds", x => x.NpcSoundId);
                    table.ForeignKey(
                        name: "FK_NPCSounds_SoundEntries_GreetingsSoundId",
                        column: x => x.GreetingsSoundId,
                        principalTable: "SoundEntries",
                        principalColumn: "SoundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NPCSounds_GreetingsSoundId",
                table: "NPCSounds",
                column: "GreetingsSoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NPCSounds");
        }
    }
}
