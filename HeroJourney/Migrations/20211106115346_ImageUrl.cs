using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroJourney.Migrations
{
    public partial class ImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Heroes");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
