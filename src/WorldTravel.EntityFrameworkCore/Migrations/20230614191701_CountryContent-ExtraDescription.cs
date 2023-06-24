using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldTravel.Migrations
{
    public partial class CountryContentExtraDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtraDescription",
                table: "AppCountryContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "AppCountryContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppCountryContent_FileId",
                table: "AppCountryContents",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCountryContents_AppFiles",
                table: "AppCountryContents",
                column: "CountryId",
                principalTable: "AppFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCountryContents_AppFiles",
                table: "AppCountryContents");

            migrationBuilder.DropIndex(
                name: "IX_AppCountryContent_FileId",
                table: "AppCountryContents");

            migrationBuilder.DropColumn(
                name: "ExtraDescription",
                table: "AppCountryContents");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AppCountryContents");
        }
    }
}
