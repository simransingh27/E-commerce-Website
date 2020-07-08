using Microsoft.EntityFrameworkCore.Migrations;

namespace Vendi.App.Data.Migrations
{
    public partial class rea1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserVisitedProducts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProductRating",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserVisitedProducts");

            migrationBuilder.DropColumn(
                name: "ProductRating",
                table: "Products");
        }
    }
}
