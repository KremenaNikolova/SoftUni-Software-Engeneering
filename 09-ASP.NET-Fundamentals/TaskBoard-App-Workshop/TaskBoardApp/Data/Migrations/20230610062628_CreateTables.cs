using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3ad88fea-2f8f-4e88-995d-5834c77f2901", 0, "3d639123-0782-4480-9896-7fce0f7f2609", null, false, false, null, "PESHO@ABV.BG", null, "AQAAAAEAACcQAAAAEAyZhDYtIIlA/7d4eDmz/INXJmSEl0G3ha7mFkLLgxJSwKXdcnWM2S1PG4fYK7OM+A==", null, false, "c6ef7a4f-1d00-40e5-bc55-fc894ba6afdc", false, "pesho@abv.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreateOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 22, 9, 26, 28, 109, DateTimeKind.Local).AddTicks(3827), "Implement better styling for all public pages", "3ad88fea-2f8f-4e88-995d-5834c77f2901", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 1, 10, 9, 26, 28, 109, DateTimeKind.Local).AddTicks(3878), "Create Android client app for the TaskBoard RESTful API", "3ad88fea-2f8f-4e88-995d-5834c77f2901", "Android Client App" },
                    { 3, 2, new DateTime(2023, 4, 10, 9, 26, 28, 109, DateTimeKind.Local).AddTicks(3883), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "3ad88fea-2f8f-4e88-995d-5834c77f2901", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 6, 10, 9, 26, 28, 109, DateTimeKind.Local).AddTicks(3886), "Implement [Create Task] page for adding new tasks", "3ad88fea-2f8f-4e88-995d-5834c77f2901", "Create Tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ad88fea-2f8f-4e88-995d-5834c77f2901");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
