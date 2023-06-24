using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldTravel.Migrations
{
    public partial class CountryContentIsSeenHomePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSeenHomePage",
                table: "AppCountryContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "AppCountryContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "AppCountryContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSeenHomePage",
                table: "AppCountryContents");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "AppCountryContents");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "AppCountryContents");
        }
    }
}
