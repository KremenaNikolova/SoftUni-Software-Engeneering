using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Data.Migrations
{
    public partial class PostSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("28d1d384-6586-4141-9965-f3c6b89beecf"), "This is my second post. CRUD operations in MVC are getting more and more interesting!", "My second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("81d15caa-1cf8-4b93-87cb-a097d8743b49"), "Hello there!'I'm getting better and better with the CRUD operations in MVC. Stay tuned!", "My third post!" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("f1495abd-9679-45b5-b032-4ffb993b5308"), "My first post will be about perfoming CRUD operations in MVC. It's so much fun!", "My first post" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("28d1d384-6586-4141-9965-f3c6b89beecf"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("81d15caa-1cf8-4b93-87cb-a097d8743b49"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f1495abd-9679-45b5-b032-4ffb993b5308"));
        }
    }
}
