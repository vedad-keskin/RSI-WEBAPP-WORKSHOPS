using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class izmjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpisGodina_Student_evidentiraoid",
                table: "UpisGodina");

            migrationBuilder.AddForeignKey(
                name: "FK_UpisGodina_KorisnickiNalog_evidentiraoid",
                table: "UpisGodina",
                column: "evidentiraoid",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpisGodina_KorisnickiNalog_evidentiraoid",
                table: "UpisGodina");

            migrationBuilder.AddForeignKey(
                name: "FK_UpisGodina_Student_evidentiraoid",
                table: "UpisGodina",
                column: "evidentiraoid",
                principalTable: "Student",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
