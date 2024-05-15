using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.DALL.Migrations
{
    public partial class std : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Studentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Studentname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Studentemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Studentphone = table.Column<int>(type: "int", nullable: false),
                    Studentposetion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Studentdescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Studentage = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extentions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Genderid = table.Column<int>(type: "int", nullable: false),
                    Listid = table.Column<int>(type: "int", nullable: false),
                    ListBooksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Studentid);
                    table.ForeignKey(
                        name: "FK_Students_Gender_Genderid",
                        column: x => x.Genderid,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_ListBooks_ListBooksId",
                        column: x => x.ListBooksId,
                        principalTable: "ListBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Genderid",
                table: "Students",
                column: "Genderid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ListBooksId",
                table: "Students",
                column: "ListBooksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
