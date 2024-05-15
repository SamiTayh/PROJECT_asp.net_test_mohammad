using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.DALL.Migrations
{
    public partial class mjj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Majaless",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genderid = table.Column<int>(type: "int", nullable: false),
                    Listid = table.Column<int>(type: "int", nullable: false),
                    ListBooksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majaless", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Majaless_Gender_Genderid",
                        column: x => x.Genderid,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Majaless_ListBooks_ListBooksId",
                        column: x => x.ListBooksId,
                        principalTable: "ListBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Majaless_Genderid",
                table: "Majaless",
                column: "Genderid");

            migrationBuilder.CreateIndex(
                name: "IX_Majaless_ListBooksId",
                table: "Majaless",
                column: "ListBooksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Majaless");
        }
    }
}
