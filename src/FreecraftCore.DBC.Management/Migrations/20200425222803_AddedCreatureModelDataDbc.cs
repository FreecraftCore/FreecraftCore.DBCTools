using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedCreatureModelDataDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreatureModelData",
                columns: table => new
                {
                    CreatureModelDataId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Flags = table.Column<int>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    SizeClass = table.Column<int>(nullable: false),
                    ModelScale = table.Column<float>(nullable: false),
                    BloodLevelId = table.Column<int>(nullable: false),
                    FootprintId = table.Column<int>(nullable: false),
                    FootprintSize_X = table.Column<float>(nullable: true),
                    FootprintSize_Y = table.Column<float>(nullable: true),
                    FootprintParticleScale = table.Column<float>(nullable: false),
                    FoleyMaterialId = table.Column<int>(nullable: false),
                    FootstepShakeId = table.Column<int>(nullable: false),
                    DeathThudShakeId = table.Column<int>(nullable: false),
                    SoundDataId = table.Column<int>(nullable: false),
                    Collision_X = table.Column<float>(nullable: true),
                    Collision_Y = table.Column<float>(nullable: true),
                    MountHeight = table.Column<float>(nullable: false),
                    GeoBoxMinimum_X = table.Column<float>(nullable: true),
                    GeoBoxMinimum_Y = table.Column<float>(nullable: true),
                    GeoBoxMinimum_Z = table.Column<float>(nullable: true),
                    GeoBoxMaximum_X = table.Column<float>(nullable: true),
                    GeoBoxMaximum_Y = table.Column<float>(nullable: true),
                    GeoBoxMaximum_Z = table.Column<float>(nullable: true),
                    WorldEffectScale = table.Column<float>(nullable: false),
                    AttachedEffectScale = table.Column<float>(nullable: false),
                    MissileCollisionRadius = table.Column<float>(nullable: false),
                    MissileCollisionPush = table.Column<float>(nullable: false),
                    MissileCollisionRaise = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureModelData", x => x.CreatureModelDataId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureModelData");
        }
    }
}
