using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedCreatureDisplayInfoDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreatureDisplayInfo",
                columns: table => new
                {
                    CreatureDisplayInfoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModelId = table.Column<int>(nullable: false),
                    SoundIdOverride = table.Column<int>(nullable: false),
                    ExtraDisplayInformationId = table.Column<int>(nullable: false),
                    CreatureModelScale = table.Column<float>(nullable: false),
                    CreatureModelAlpha = table.Column<int>(nullable: false),
                    TextureVariation_One = table.Column<string>(nullable: true),
                    TextureVariation_Two = table.Column<string>(nullable: true),
                    TextureVariation_Three = table.Column<string>(nullable: true),
                    PortraitTextureName = table.Column<string>(nullable: true),
                    BloodLevelIdOverride = table.Column<int>(nullable: false),
                    UnitBloodId = table.Column<int>(nullable: false),
                    NpcSoundsId = table.Column<int>(nullable: false),
                    ParticleId = table.Column<int>(nullable: false),
                    CreatureGeosetData = table.Column<int>(nullable: false),
                    ObjectEffectPackageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureDisplayInfo", x => x.CreatureDisplayInfoId);
                    table.ForeignKey(
                        name: "FK_CreatureDisplayInfo_CreatureModelData_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CreatureModelData",
                        principalColumn: "CreatureModelDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreatureDisplayInfo_ModelId",
                table: "CreatureDisplayInfo",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureDisplayInfo");
        }
    }
}
