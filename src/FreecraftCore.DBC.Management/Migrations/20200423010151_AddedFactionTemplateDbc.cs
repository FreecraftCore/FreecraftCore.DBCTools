using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedFactionTemplateDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FactionTemplate",
                columns: table => new
                {
                    FactionTemplateId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FactionId = table.Column<int>(nullable: false),
                    FactionFlags = table.Column<int>(nullable: false),
                    OwnFactionGroupMask = table.Column<int>(nullable: false),
                    FriendlyFactionGroupMask = table.Column<int>(nullable: false),
                    EnemyFactionGroupMask = table.Column<int>(nullable: false),
                    EnemyFaction_X = table.Column<int>(nullable: true),
                    EnemyFaction_Y = table.Column<int>(nullable: true),
                    EnemyFaction_Z = table.Column<int>(nullable: true),
                    EnemyFaction_W = table.Column<int>(nullable: true),
                    FriendlyFaction_X = table.Column<int>(nullable: true),
                    FriendlyFaction_Y = table.Column<int>(nullable: true),
                    FriendlyFaction_Z = table.Column<int>(nullable: true),
                    FriendlyFaction_W = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionTemplate", x => x.FactionTemplateId);
                    table.ForeignKey(
                        name: "FK_FactionTemplate_Faction_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Faction",
                        principalColumn: "FactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactionTemplate_FactionId",
                table: "FactionTemplate",
                column: "FactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactionTemplate");
        }
    }
}
