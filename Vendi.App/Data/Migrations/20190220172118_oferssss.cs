using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vendi.App.Data.Migrations
{
    public partial class oferssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceReviews_ServiceModelView_ServiceId",
                table: "ServiceReviews");

            migrationBuilder.DropTable(
                name: "ServiceModelView");

            migrationBuilder.DropIndex(
                name: "IX_ServiceReviews_ServiceId",
                table: "ServiceReviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceModelView",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ServiceName = table.Column<string>(nullable: true),
                    ServiceRating = table.Column<double>(nullable: false),
                    Tags = table.Column<string>(nullable: true)
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
    }
}
