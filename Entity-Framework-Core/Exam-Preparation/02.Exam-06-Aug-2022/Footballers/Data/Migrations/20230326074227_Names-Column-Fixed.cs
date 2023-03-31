using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Footballers.Migrations
{
    public partial class NamesColumnFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footballers_Coachs_CoachId",
                table: "Footballers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coachs",
                table: "Coachs");

            migrationBuilder.RenameTable(
                name: "Coachs",
                newName: "Coaches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Footballers_Coaches_CoachId",
                table: "Footballers",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footballers_Coaches_CoachId",
                table: "Footballers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches");

            migrationBuilder.RenameTable(
                name: "Coaches",
                newName: "Coachs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coachs",
                table: "Coachs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Footballers_Coachs_CoachId",
                table: "Footballers",
                column: "CoachId",
                principalTable: "Coachs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
