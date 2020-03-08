using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CraigslistClone.Migrations
{
    public partial class AddingImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "imagesId",
                table: "Listings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListingImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingImages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_imagesId",
                table: "Listings",
                column: "imagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_ListingImages_imagesId",
                table: "Listings",
                column: "imagesId",
                principalTable: "ListingImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_ListingImages_imagesId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "ListingImages");

            migrationBuilder.DropIndex(
                name: "IX_Listings_imagesId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "imagesId",
                table: "Listings");
        }
    }
}
