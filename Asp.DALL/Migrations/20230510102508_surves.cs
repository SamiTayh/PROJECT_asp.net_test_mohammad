using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.DALL.Migrations
{
    public partial class surves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scientaficPromationss_ListBooks_listBooksId",
                table: "scientaficPromationss");

            migrationBuilder.RenameColumn(
                name: "listBooksId",
                table: "scientaficPromationss",
                newName: "ListBooksId");

            migrationBuilder.RenameIndex(
                name: "IX_scientaficPromationss_listBooksId",
                table: "scientaficPromationss",
                newName: "IX_scientaficPromationss_ListBooksId");

            migrationBuilder.CreateTable(
                name: "surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genderid = table.Column<int>(type: "int", nullable: false),
                    Listid = table.Column<int>(type: "int", nullable: false),
                    ListBooksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_surveys_Gender_Genderid",
                        column: x => x.Genderid,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_surveys_ListBooks_ListBooksId",
                        column: x => x.ListBooksId,
                        principalTable: "ListBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_surveys_Genderid",
                table: "surveys",
                column: "Genderid");

            migrationBuilder.CreateIndex(
                name: "IX_surveys_ListBooksId",
                table: "surveys",
                column: "ListBooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_scientaficPromationss_ListBooks_ListBooksId",
                table: "scientaficPromationss",
                column: "ListBooksId",
                principalTable: "ListBooks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scientaficPromationss_ListBooks_ListBooksId",
                table: "scientaficPromationss");

            migrationBuilder.DropTable(
                name: "surveys");

            migrationBuilder.RenameColumn(
                name: "ListBooksId",
                table: "scientaficPromationss",
                newName: "listBooksId");

            migrationBuilder.RenameIndex(
                name: "IX_scientaficPromationss_ListBooksId",
                table: "scientaficPromationss",
                newName: "IX_scientaficPromationss_listBooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_scientaficPromationss_ListBooks_listBooksId",
                table: "scientaficPromationss",
                column: "listBooksId",
                principalTable: "ListBooks",
                principalColumn: "Id");
        }
    }
}
