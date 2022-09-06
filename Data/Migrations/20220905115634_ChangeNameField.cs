using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCurso.Data.Migrations
{
    public partial class ChangeNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlVideoAula",
                table: "Modulo",
                newName: "OrdemDeExibicao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrdemDeExibicao",
                table: "Modulo",
                newName: "UrlVideoAula");
        }
    }
}
