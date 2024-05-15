using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.DALL.Migrations
{
    public partial class ethreaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ethreaass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genderid = table.Column<int>(type: "int", nullable: false),
                    Listid = table.Column<int>(type: "int", nullable: false),
                    ListBooksId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethreaass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ethreaass_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ethreaass_Gender_Genderid",
                        column: x => x.Genderid,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ethreaass_ListBooks_ListBooksId",
                        column: x => x.ListBooksId,
                        principalTable: "ListBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ethreaass_AuthorId",
                table: "Ethreaass",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ethreaass_Genderid",
                table: "Ethreaass",
                column: "Genderid");

            migrationBuilder.CreateIndex(
                name: "IX_Ethreaass_ListBooksId",
                table: "Ethreaass",
                column: "ListBooksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ethreaass");
        }
    }
}
