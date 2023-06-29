using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0b766140-c034-408c-bf42-d8ac5e39ca33", 0, "3d8c57f3-16cc-42c5-ab78-8e43410b2428", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAED3K7+szo/Lcigwe+Yo+rnb9ynG7OTOjAaRvG3l4etYPK7euPsJ9+joI2FOH6l1QSQ==", null, false, "f924ad98-3202-44f7-b70f-2cef21a73366", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 25, 18, 31, 16, 296, DateTimeKind.Local).AddTicks(3625), "Implement better styling for all public pages", "0b766140-c034-408c-bf42-d8ac5e39ca33", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 1, 13, 18, 31, 16, 296, DateTimeKind.Local).AddTicks(3665), "Create Android client app for the TaskBoard Restful API", "0b766140-c034-408c-bf42-d8ac5e39ca33", "Android Client App" },
                    { 3, 2, new DateTime(2023, 5, 13, 18, 31, 16, 296, DateTimeKind.Local).AddTicks(3670), "Create Windows Forms desktop app client for the TaskBoard Restful API", "0b766140-c034-408c-bf42-d8ac5e39ca33", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 6, 13, 18, 31, 16, 296, DateTimeKind.Local).AddTicks(3673), "Implement [Create Task] page for adding new tasks", "0b766140-c034-408c-bf42-d8ac5e39ca33", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b766140-c034-408c-bf42-d8ac5e39ca33");
        }
    }
}
