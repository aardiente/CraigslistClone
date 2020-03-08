using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CraigslistClone.Migrations
{
    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_ListingImages_imagesId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_imagesId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "imagesId",
                table: "Listings");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "ListingImages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "ListingImages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThreadId",
                table: "ListingImages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ListingImages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListingImages_ListingId",
                table: "ListingImages",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingImages_Listings_ListingId",
                table: "ListingImages",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingImages_Listings_ListingId",
                table: "ListingImages");

            migrationBuilder.DropIndex(
                name: "IX_ListingImages_ListingId",
                table: "ListingImages");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "ListingImages");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "ListingImages");

            migrationBuilder.DropColumn(
                name: "ThreadId",
                table: "ListingImages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ListingImages");

            migrationBuilder.AddColumn<int>(
                name: "imagesId",
                table: "Listings",
                nullable: true);

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
    }
}
