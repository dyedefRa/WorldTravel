using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldTravel.Migrations
{
    public partial class UserAppUserRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AbpUsers",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppCities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CityNo = table.Column<int>(type: "int", nullable: false),
                    AreaNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FullPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MailKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MailTemplateValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderStatus = table.Column<int>(type: "int", nullable: false),
                    ReceiverStatus = table.Column<int>(type: "int", nullable: false),
                    SenderStatusDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiverStatusDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSentMails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CcAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BccAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSentMails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTowns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TownNo = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTowns_AppCities_CityId",
                        column: x => x.CityId,
                        principalTable: "AppCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppMessageContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedForSender = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedForReceiver = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateForSender = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDateForReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMessageContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMessageContents_AppMessages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "AppMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_ImageId",
                table: "AbpUsers",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppMessageContents_MessageId",
                table: "AppMessageContents",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTowns_CityId",
                table: "AppTowns",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_AppFiles_ImageId",
                table: "AbpUsers",
                column: "ImageId",
                principalTable: "AppFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_AppFiles_ImageId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "AppCountries");

            migrationBuilder.DropTable(
                name: "AppFiles");

            migrationBuilder.DropTable(
                name: "AppLogs");

            migrationBuilder.DropTable(
                name: "AppMailTemplates");

            migrationBuilder.DropTable(
                name: "AppMessageContents");

            migrationBuilder.DropTable(
                name: "AppSentMails");

            migrationBuilder.DropTable(
                name: "AppTowns");

            migrationBuilder.DropTable(
                name: "AppMessages");

            migrationBuilder.DropTable(
                name: "AppCities");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_ImageId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AbpUsers");
        }
    }
}
