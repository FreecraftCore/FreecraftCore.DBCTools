using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedItemDisplayInfoDBC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDisplayInfo",
                columns: table => new
                {
                    ItemDisplayId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LeftModelName = table.Column<string>(nullable: true),
                    RightModelName = table.Column<string>(nullable: true),
                    LeftModelTextureName = table.Column<string>(nullable: true),
                    RightModelTextureName = table.Column<string>(nullable: true),
                    InventoryIcon1 = table.Column<string>(nullable: true),
                    InventoryIcon2 = table.Column<string>(nullable: true),
                    GeosetGroup_X = table.Column<int>(nullable: true),
                    GeosetGroup_Y = table.Column<int>(nullable: true),
                    GeosetGroup_Z = table.Column<int>(nullable: true),
                    Flags = table.Column<int>(nullable: false),
                    SpellVisualId = table.Column<int>(nullable: false),
                    GroupSoundId = table.Column<int>(nullable: false),
                    HelmentGeosetVisualMale = table.Column<int>(nullable: false),
                    HelmentGeosetVisualFemale = table.Column<int>(nullable: false),
                    UpperArmTextureName = table.Column<string>(nullable: true),
                    LowerArmTextureName = table.Column<string>(nullable: true),
                    HandsTextureName = table.Column<string>(nullable: true),
                    UpperTorsoTextureName = table.Column<string>(nullable: true),
                    LowerTorsoTextureName = table.Column<string>(nullable: true),
                    UpperLegTextureName = table.Column<string>(nullable: true),
                    LowerLegTextureName = table.Column<string>(nullable: true),
                    FootTextureName = table.Column<string>(nullable: true),
                    ItemVisualId = table.Column<int>(nullable: false),
                    ParticleColorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDisplayInfo", x => x.ItemDisplayId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDisplayInfo");
        }
    }
}
