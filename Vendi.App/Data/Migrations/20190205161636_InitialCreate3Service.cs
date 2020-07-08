using Microsoft.EntityFrameworkCore.Migrations;

namespace Vendi.App.Data.Migrations
{
    public partial class InitialCreate3Service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ServiceId",
                table: "Categories",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Services_ServiceId",
                table: "Categories",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Services_ServiceId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ServiceId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Categories");
        }
    }
}
