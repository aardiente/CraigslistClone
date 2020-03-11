using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CraigslistClone.Migrations
{
    public partial class AdditionalListingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Threads_hostThreadId",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "hostThreadId",
                table: "Listings",
                newName: "hostThreadID");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_hostThreadId",
                table: "Listings",
                newName: "IX_Listings_hostThreadID");

            migrationBuilder.AlterColumn<int>(
                name: "hostThreadID",
                table: "Listings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Listings",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Threads_hostThreadID",
                table: "Listings",
                column: "hostThreadID",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Threads_hostThreadID",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Listings");

            migrationBuilder.RenameColumn(
                name: "hostThreadID",
                table: "Listings",
                newName: "hostThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_hostThreadID",
                table: "Listings",
                newName: "IX_Listings_hostThreadId");

            migrationBuilder.AlterColumn<int>(
                name: "hostThreadId",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(int));

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
