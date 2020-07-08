using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vendi.App.Data.Migrations
{
    public partial class busAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "Services",
                newName: "IsStatus");

            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "Products",
                newName: "IsStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "ServiceOffers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "ServiceOffers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BusinessAddresses",
                columns: table => new
                {
                    BusinessAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostCode = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Longitute = table.Column<double>(nullable: false),
                    Latitue = table.Column<double>(nullable: false),
                    ServiceCategoryId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAddresses", x => x.BusinessAddressId);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedServices",
                columns: table => new
                {
                    FeatureServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FeaturedFrom = table.Column<DateTime>(nullable: false),
                    FeaturedTo = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedServices", x => x.FeatureServiceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessAddresses");

            migrationBuilder.DropTable(
                name: "FeaturedServices");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "ServiceOffers");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "ServiceOffers");

            migrationBuilder.RenameColumn(
                name: "IsStatus",
                table: "Services",
                newName: "IsAccepted");

            migrationBuilder.RenameColumn(
                name: "IsStatus",
                table: "Products",
                newName: "IsAccepted");
        }
    }
}
