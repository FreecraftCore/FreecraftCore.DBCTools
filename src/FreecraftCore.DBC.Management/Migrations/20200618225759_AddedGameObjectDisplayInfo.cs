using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedGameObjectDisplayInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameObjectDisplayInfo",
                columns: table => new
                {
                    GameObjectDisplayInfoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModelPath = table.Column<string>(nullable: true),
                    SoundSlot_One = table.Column<int>(nullable: true),
                    SoundSlot_Two = table.Column<int>(nullable: true),
                    SoundSlot_Three = table.Column<int>(nullable: true),
                    SoundSlot_Four = table.Column<int>(nullable: true),
                    SoundSlot_Five = table.Column<int>(nullable: true),
                    SoundSlot_Six = table.Column<int>(nullable: true),
                    SoundSlot_Seven = table.Column<int>(nullable: true),
                    SoundSlot_Eight = table.Column<int>(nullable: true),
                    SoundSlot_Nine = table.Column<int>(nullable: true),
                    SoundSlot_Ten = table.Column<int>(nullable: true),
                    BoxMin_X = table.Column<float>(nullable: true),
                    BoxMin_Y = table.Column<float>(nullable: true),
                    BoxMin_Z = table.Column<float>(nullable: true),
                    BoxMax_X = table.Column<float>(nullable: true),
                    BoxMax_Y = table.Column<float>(nullable: true),
                    BoxMax_Z = table.Column<float>(nullable: true),
                    ObjectEffectsPackageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameObjectDisplayInfo", x => x.GameObjectDisplayInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameObjectDisplayInfo");
        }
    }
}
