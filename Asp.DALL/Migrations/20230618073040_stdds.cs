using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.DALL.Migrations
{
    public partial class stdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Manegmentid",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    ListBooksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manegments_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Manegments_ListBooks_ListBooksId",
                        column: x => x.ListBooksId,
                        principalTable: "ListBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Manegmentid",
                table: "Students",
                column: "Manegmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Manegments_GenderId",
                table: "Manegments",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Manegments_ListBooksId",
                table: "Manegments",
                column: "ListBooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Manegments_Manegmentid",
                table: "Students",
                column: "Manegmentid",
                principalTable: "Manegments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Manegments_Manegmentid",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Manegments");

            migrationBuilder.DropIndex(
                name: "IX_Students_Manegmentid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Manegmentid",
                table: "Students");
        }
    }
}
