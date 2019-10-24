using Microsoft.EntityFrameworkCore.Migrations;

namespace CraigslistClone.Data.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Threads_hostThreadId",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "hostThreadId",
                table: "Listings",
                newName: "HostCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_hostThreadId",
                table: "Listings",
                newName: "IX_Listings_HostCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Threads_HostCategoryId",
                table: "Listings",
                column: "HostCategoryId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Threads_HostCategoryId",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "HostCategoryId",
                table: "Listings",
                newName: "hostThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_HostCategoryId",
                table: "Listings",
                newName: "IX_Listings_hostThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Threads_hostThreadId",
                table: "Listings",
                column: "hostThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
