using Microsoft.EntityFrameworkCore.Migrations;

namespace CraigslistClone.Migrations
{
    public partial class testinguser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsersID",
                table: "Listings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsersID",
                table: "Listings");
        }
    }
}
