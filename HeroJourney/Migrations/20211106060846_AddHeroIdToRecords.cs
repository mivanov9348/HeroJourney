using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroJourney.Migrations
{
    public partial class AddHeroIdToRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "HeroRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "HeroRecords");
        }
    }
}
