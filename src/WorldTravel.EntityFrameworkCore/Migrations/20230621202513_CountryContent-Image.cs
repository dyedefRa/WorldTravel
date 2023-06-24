using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldTravel.Migrations
{
    public partial class CountryContentImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCountryContents_AppFiles",
                table: "AppCountryContents");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCountryContents_AppFiles",
                table: "AppCountryContents",
                column: "ImageId",
                principalTable: "AppFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCountryContents_AppFiles",
                table: "AppCountryContents");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCountryContents_AppFiles",
                table: "AppCountryContents",
                column: "CountryId",
                principalTable: "AppFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
