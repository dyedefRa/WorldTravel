using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldTravel.Migrations
{
    public partial class CountryContentFileType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppShareContentFiles");

            migrationBuilder.DropTable(
                name: "AppShareContents");

            migrationBuilder.AddColumn<bool>(
                name: "IsShareContent",
                table: "AppCountryContentFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShareContent",
                table: "AppCountryContentFiles");

            migrationBuilder.CreateTable(
                name: "AppShareContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ValidDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppShareContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppShareContents_AppCountries",
                        column: x => x.CountryId,
                        principalTable: "AppCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppShareContentFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    ShareContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppShareContentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppShareContentFiles_AppFiles",
                        column: x => x.FileId,
                        principalTable: "AppFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppShareContentFiles_AppShareContents",
                        column: x => x.ShareContentId,
                        principalTable: "AppShareContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppShareContentFile_FileId",
                table: "AppShareContentFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_AppShareContentFile_ShareContentId",
                table: "AppShareContentFiles",
                column: "ShareContentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppShareContent_CountryId",
                table: "AppShareContents",
                column: "CountryId");
        }
    }
}
