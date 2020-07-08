using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vendi.App.Data.Migrations
{
    public partial class favser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Services",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "ServiceRating",
                table: "Services",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AdsName",
                table: "Ads",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ServiceFavorites",
                columns: table => new
                {
                    ServiceFavoriteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFavorites", x => x.ServiceFavoriteId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceModelView",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ServiceRating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceModelView", x => x.ServiceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReviews_ServiceId",
                table: "ServiceReviews",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceReviews_ServiceModelView_ServiceId",
                table: "ServiceReviews",
                column: "ServiceId",
                principalTable: "ServiceModelView",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReviews_ServiceModelView_ServiceId",
                table: "ServiceReviews");

            migrationBuilder.DropTable(
                name: "ServiceFavorites");

            migrationBuilder.DropTable(
                name: "ServiceModelView");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReviews_ServiceId",
                table: "ServiceReviews");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceRating",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AdsName",
                table: "Ads");
        }
    }
}
