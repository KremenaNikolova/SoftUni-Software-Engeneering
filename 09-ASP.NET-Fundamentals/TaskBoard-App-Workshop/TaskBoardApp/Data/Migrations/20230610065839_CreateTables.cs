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
                values: new object[] { "8b49f4a7-3091-410a-b71d-542235764c39", 0, "b1816c73-c356-42d9-97fe-ab9dc2f88696", null, false, false, null, null, "PESHO@ABV.BG", "AQAAAAEAACcQAAAAEHjmV9SOpHHhcMPaulqFTmT9k6hiJgsisDpop3fZHw2BRHUaIbLe0PVYncSq44mNSg==", null, false, "90713df4-e92e-493b-9ebd-100ab5220477", false, "pesho@abv.bg" });

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
                    { 1, 1, new DateTime(2022, 11, 22, 9, 58, 39, 159, DateTimeKind.Local).AddTicks(3383), "Implement better styling for all public pages", "8b49f4a7-3091-410a-b71d-542235764c39", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 1, 10, 9, 58, 39, 159, DateTimeKind.Local).AddTicks(3435), "Create Android client app for the TaskBoard RESTful API", "8b49f4a7-3091-410a-b71d-542235764c39", "Android Client App" },
                    { 3, 2, new DateTime(2023, 4, 10, 9, 58, 39, 159, DateTimeKind.Local).AddTicks(3440), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "8b49f4a7-3091-410a-b71d-542235764c39", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 6, 10, 9, 58, 39, 159, DateTimeKind.Local).AddTicks(3443), "Implement [Create Task] page for adding new tasks", "8b49f4a7-3091-410a-b71d-542235764c39", "Create Tasks" }
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
                keyValue: "8b49f4a7-3091-410a-b71d-542235764c39");

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
