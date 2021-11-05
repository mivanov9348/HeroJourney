using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroJourney.Migrations
{
    public partial class AddTurnToArena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "ArenaStats",
                newName: "Turn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Turn",
                table: "ArenaStats",
                newName: "MyProperty");
        }
    }
}
