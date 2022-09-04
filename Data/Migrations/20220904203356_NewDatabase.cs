using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCurso.Data.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Modulos_ModuloId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Modulos_Cursos_CursoId",
                table: "Modulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modulos",
                table: "Modulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas");

            migrationBuilder.RenameTable(
                name: "Modulos",
                newName: "Modulo");

            migrationBuilder.RenameTable(
                name: "Cursos",
                newName: "Curso");

            migrationBuilder.RenameTable(
                name: "Aulas",
                newName: "Aula");

            migrationBuilder.RenameColumn(
                name: "OrdemExibicao",
                table: "Modulo",
                newName: "UrlVideoAula");

            migrationBuilder.RenameIndex(
                name: "IX_Modulos_CursoId",
                table: "Modulo",
                newName: "IX_Modulo_CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Aulas_ModuloId",
                table: "Aula",
                newName: "IX_Aula_ModuloId");

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "Modulo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModuloId",
                table: "Aula",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modulo",
                table: "Modulo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curso",
                table: "Curso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aula",
                table: "Aula",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_Modulo",
                table: "Aula",
                column: "ModuloId",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modulo_Curso",
                table: "Modulo",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aula_Modulo",
                table: "Aula");

            migrationBuilder.DropForeignKey(
                name: "FK_Modulo_Curso",
                table: "Modulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modulo",
                table: "Modulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curso",
                table: "Curso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aula",
                table: "Aula");

            migrationBuilder.RenameTable(
                name: "Modulo",
                newName: "Modulos");

            migrationBuilder.RenameTable(
                name: "Curso",
                newName: "Cursos");

            migrationBuilder.RenameTable(
                name: "Aula",
                newName: "Aulas");

            migrationBuilder.RenameColumn(
                name: "UrlVideoAula",
                table: "Modulos",
                newName: "OrdemExibicao");

            migrationBuilder.RenameIndex(
                name: "IX_Modulo_CursoId",
                table: "Modulos",
                newName: "IX_Modulos_CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Aula_ModuloId",
                table: "Aulas",
                newName: "IX_Aulas_ModuloId");

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "Modulos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ModuloId",
                table: "Aulas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modulos",
                table: "Modulos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aulas",
                table: "Aulas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Modulos_ModuloId",
                table: "Aulas",
                column: "ModuloId",
                principalTable: "Modulos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modulos_Cursos_CursoId",
                table: "Modulos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id");
        }
    }
}
