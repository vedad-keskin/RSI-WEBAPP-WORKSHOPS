using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class UpisGodine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpisGodina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumUpisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    godinaStudija = table.Column<int>(type: "int", nullable: false),
                    akademskaGodinaid = table.Column<int>(type: "int", nullable: false),
                    cijenaSkolarine = table.Column<float>(type: "real", nullable: false),
                    obnova = table.Column<bool>(type: "bit", nullable: false),
                    datumObnove = table.Column<DateTime>(type: "datetime2", nullable: true),
                    napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentid = table.Column<int>(type: "int", nullable: false),
                    evidentiraoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisGodina", x => x.id);
                    table.ForeignKey(
                        name: "FK_UpisGodina_AkademskaGodina_akademskaGodinaid",
                        column: x => x.akademskaGodinaid,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpisGodina_Student_evidentiraoid",
                        column: x => x.evidentiraoid,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpisGodina_Student_studentid",
                        column: x => x.studentid,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpisGodina_akademskaGodinaid",
                table: "UpisGodina",
                column: "akademskaGodinaid");

            migrationBuilder.CreateIndex(
                name: "IX_UpisGodina_evidentiraoid",
                table: "UpisGodina",
                column: "evidentiraoid");

            migrationBuilder.CreateIndex(
                name: "IX_UpisGodina_studentid",
                table: "UpisGodina",
                column: "studentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpisGodina");
        }
    }
}
