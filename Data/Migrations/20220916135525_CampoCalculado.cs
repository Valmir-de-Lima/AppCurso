using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCurso.Data.Migrations
{
    public partial class CampoCalculado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DuracaoEmHoras",
                table: "Curso",
                type: "INTEGER",
                nullable: false,
                computedColumnSql: "[DuracaoEmMinutos] / 60");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuracaoEmHoras",
                table: "Curso");
        }
    }
}
