using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroJourney.Migrations
{
    public partial class AddArena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArenaStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyId = table.Column<int>(type: "int", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    HeroDamage = table.Column<int>(type: "int", nullable: false),
                    EnemyDamage = table.Column<int>(type: "int", nullable: false),
                    HeroWinsXp = table.Column<int>(type: "int", nullable: false),
                    HeroWinsCoins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArenaStats_EnemyRecords_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "EnemyRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArenaStats_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArenaStats_EnemyId",
                table: "ArenaStats",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_ArenaStats_HeroId",
                table: "ArenaStats",
                column: "HeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArenaStats");
        }
    }
}
