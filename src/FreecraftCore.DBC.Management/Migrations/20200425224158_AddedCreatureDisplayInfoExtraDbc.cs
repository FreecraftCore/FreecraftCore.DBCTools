using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedCreatureDisplayInfoExtraDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreatureDisplayInfoExtra",
                columns: table => new
                {
                    CreatureDisplayInfoExtraId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    SkinId = table.Column<int>(nullable: false),
                    FaceId = table.Column<int>(nullable: false),
                    HairId = table.Column<int>(nullable: false),
                    HairColorId = table.Column<int>(nullable: false),
                    FacialHairId = table.Column<int>(nullable: false),
                    HelmItemId = table.Column<int>(nullable: false),
                    ShoulderItemId = table.Column<int>(nullable: false),
                    ShirtItemId = table.Column<int>(nullable: false),
                    CuirassItemId = table.Column<int>(nullable: false),
                    BeltItemId = table.Column<int>(nullable: false),
                    LegsItemId = table.Column<int>(nullable: false),
                    BootsItemId = table.Column<int>(nullable: false),
                    WristItemId = table.Column<int>(nullable: false),
                    GlovesItemId = table.Column<int>(nullable: false),
                    TabardItemId = table.Column<int>(nullable: false),
                    CapeItemId = table.Column<int>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    BakedTextureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureDisplayInfoExtra", x => x.CreatureDisplayInfoExtraId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureDisplayInfoExtra");
        }
    }
}
