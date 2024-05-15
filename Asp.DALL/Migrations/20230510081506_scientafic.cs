using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.DALL.Migrations
{
    public partial class scientafic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBooks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "scientaficPromationss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromationRate = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genderid = table.Column<int>(type: "int", nullable: false),
                    listid = table.Column<int>(type: "int", nullable: false),
                    listBooksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scientaficPromationss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scientaficPromationss_Gender_Genderid",
                        column: x => x.Genderid,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scientaficPromationss_ListBooks_listBooksId",
                        column: x => x.listBooksId,
                        principalTable: "ListBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_scientaficPromationss_Genderid",
                table: "scientaficPromationss",
                column: "Genderid");

            migrationBuilder.CreateIndex(
                name: "IX_scientaficPromationss_listBooksId",
                table: "scientaficPromationss",
                column: "listBooksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scientaficPromationss");

            migrationBuilder.DropTable(
                name: "ListBooks");
        }
    }
}
