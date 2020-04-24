using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreecraftCore.DBC.Management.Migrations
{
    public partial class AddedCreatureSoundDataDbc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreatureSoundData",
                columns: table => new
                {
                    CreatureSoundDataId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SoundExertionId = table.Column<int>(nullable: false),
                    SoundExertionCriticalId = table.Column<int>(nullable: false),
                    SoundInjuryId = table.Column<int>(nullable: false),
                    SoundInjuryCriticalId = table.Column<int>(nullable: false),
                    SoundInjuryCrushingBlowId = table.Column<int>(nullable: false),
                    SoundDeathId = table.Column<int>(nullable: false),
                    SoundStunId = table.Column<int>(nullable: false),
                    SoundStandId = table.Column<int>(nullable: false),
                    SoundFootstepId = table.Column<int>(nullable: false),
                    SoundAggroId = table.Column<int>(nullable: false),
                    SoundWingFlapId = table.Column<int>(nullable: false),
                    SoundWingGlideId = table.Column<int>(nullable: false),
                    SoundAlertId = table.Column<int>(nullable: false),
                    SoundFidgetId_One = table.Column<int>(nullable: true),
                    SoundFidgetId_Two = table.Column<int>(nullable: true),
                    SoundFidgetId_Three = table.Column<int>(nullable: true),
                    SoundFidgetId_Four = table.Column<int>(nullable: true),
                    SoundFidgetId_Five = table.Column<int>(nullable: true),
                    CustomAttackId_One = table.Column<int>(nullable: true),
                    CustomAttackId_Two = table.Column<int>(nullable: true),
                    CustomAttackId_Three = table.Column<int>(nullable: true),
                    CustomAttackId_Four = table.Column<int>(nullable: true),
                    NPCSoundId = table.Column<int>(nullable: false),
                    LoopSoundId = table.Column<int>(nullable: false),
                    CreatureImpactType = table.Column<int>(nullable: false),
                    SoundJumpStartId = table.Column<int>(nullable: false),
                    SoundJumpEndId = table.Column<int>(nullable: false),
                    SoundPetAttackId = table.Column<int>(nullable: false),
                    SoundPetOrderId = table.Column<int>(nullable: false),
                    SoundPetDismissId = table.Column<int>(nullable: false),
                    FidgetDelaySecondsMinimum = table.Column<float>(nullable: false),
                    FidgetDelaySecondsMaximum = table.Column<float>(nullable: false),
                    BirthSoundId = table.Column<int>(nullable: false),
                    SpellCastDirectedSoundId = table.Column<int>(nullable: false),
                    SubmergeSoundId = table.Column<int>(nullable: false),
                    SubmergedSoundId = table.Column<int>(nullable: false),
                    CreatureSoundDataIdPet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSoundData", x => x.CreatureSoundDataId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureSoundData");
        }
    }
}
