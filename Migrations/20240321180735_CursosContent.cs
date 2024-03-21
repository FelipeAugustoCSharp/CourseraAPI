using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CursosContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoDados_CursoContent_CursoContentId",
                table: "CursoDados");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoDados_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                table: "CursoDados");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoNivel_CursoContent_CursoContentId",
                table: "CursoNivel");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoNivel_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                table: "CursoNivel");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCadastro_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                table: "UsuarioCadastro");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioCadastro_UsuarioCursoNivelModelId",
                table: "UsuarioCadastro");

            migrationBuilder.DropIndex(
                name: "IX_CursoNivel_CursoContentId",
                table: "CursoNivel");

            migrationBuilder.DropIndex(
                name: "IX_CursoNivel_UsuarioCursoNivelModelId",
                table: "CursoNivel");

            migrationBuilder.DropIndex(
                name: "IX_CursoDados_CursoContentId",
                table: "CursoDados");

            migrationBuilder.DropIndex(
                name: "IX_CursoDados_UsuarioCursoNivelModelId",
                table: "CursoDados");

            migrationBuilder.DropColumn(
                name: "UsuarioCursoNivelModelId",
                table: "UsuarioCadastro");

            migrationBuilder.DropColumn(
                name: "CursoContentId",
                table: "CursoNivel");

            migrationBuilder.DropColumn(
                name: "UsuarioCursoNivelModelId",
                table: "CursoNivel");

            migrationBuilder.DropColumn(
                name: "CursoContentId",
                table: "CursoDados");

            migrationBuilder.DropColumn(
                name: "UsuarioCursoNivelModelId",
                table: "CursoDados");

            migrationBuilder.AddColumn<int>(
                name: "CursoDadosId",
                table: "UsuarioCursoNivel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CursoNivelId",
                table: "UsuarioCursoNivel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "UsuarioCursoNivel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CursoDadosId",
                table: "CursoContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CursoNivelId",
                table: "CursoContent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCursoNivel_CursoDadosId",
                table: "UsuarioCursoNivel",
                column: "CursoDadosId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCursoNivel_CursoNivelId",
                table: "UsuarioCursoNivel",
                column: "CursoNivelId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCursoNivel_UsuarioId",
                table: "UsuarioCursoNivel",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoContent_CursoDadosId",
                table: "CursoContent",
                column: "CursoDadosId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoContent_CursoNivelId",
                table: "CursoContent",
                column: "CursoNivelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoContent_CursoDados_CursoDadosId",
                table: "CursoContent",
                column: "CursoDadosId",
                principalTable: "CursoDados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoContent_CursoNivel_CursoNivelId",
                table: "CursoContent",
                column: "CursoNivelId",
                principalTable: "CursoNivel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCursoNivel_CursoDados_CursoDadosId",
                table: "UsuarioCursoNivel",
                column: "CursoDadosId",
                principalTable: "CursoDados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCursoNivel_CursoNivel_CursoNivelId",
                table: "UsuarioCursoNivel",
                column: "CursoNivelId",
                principalTable: "CursoNivel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCursoNivel_UsuarioCadastro_UsuarioId",
                table: "UsuarioCursoNivel",
                column: "UsuarioId",
                principalTable: "UsuarioCadastro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoContent_CursoDados_CursoDadosId",
                table: "CursoContent");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoContent_CursoNivel_CursoNivelId",
                table: "CursoContent");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCursoNivel_CursoDados_CursoDadosId",
                table: "UsuarioCursoNivel");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCursoNivel_CursoNivel_CursoNivelId",
                table: "UsuarioCursoNivel");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCursoNivel_UsuarioCadastro_UsuarioId",
                table: "UsuarioCursoNivel");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioCursoNivel_CursoDadosId",
                table: "UsuarioCursoNivel");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioCursoNivel_CursoNivelId",
                table: "UsuarioCursoNivel");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioCursoNivel_UsuarioId",
                table: "UsuarioCursoNivel");

            migrationBuilder.DropIndex(
                name: "IX_CursoContent_CursoDadosId",
                table: "CursoContent");

            migrationBuilder.DropIndex(
                name: "IX_CursoContent_CursoNivelId",
                table: "CursoContent");

            migrationBuilder.DropColumn(
                name: "CursoDadosId",
                table: "UsuarioCursoNivel");

            migrationBuilder.DropColumn(
                name: "CursoNivelId",
                table: "UsuarioCursoNivel");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UsuarioCursoNivel");

            migrationBuilder.DropColumn(
                name: "CursoDadosId",
                table: "CursoContent");

            migrationBuilder.DropColumn(
                name: "CursoNivelId",
                table: "CursoContent");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCursoNivelModelId",
                table: "UsuarioCadastro",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CursoContentId",
                table: "CursoNivel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCursoNivelModelId",
                table: "CursoNivel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CursoContentId",
                table: "CursoDados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCursoNivelModelId",
                table: "CursoDados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCadastro_UsuarioCursoNivelModelId",
                table: "UsuarioCadastro",
                column: "UsuarioCursoNivelModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoNivel_CursoContentId",
                table: "CursoNivel",
                column: "CursoContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoNivel_UsuarioCursoNivelModelId",
                table: "CursoNivel",
                column: "UsuarioCursoNivelModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDados_CursoContentId",
                table: "CursoDados",
                column: "CursoContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDados_UsuarioCursoNivelModelId",
                table: "CursoDados",
                column: "UsuarioCursoNivelModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoDados_CursoContent_CursoContentId",
                table: "CursoDados",
                column: "CursoContentId",
                principalTable: "CursoContent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoDados_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                table: "CursoDados",
                column: "UsuarioCursoNivelModelId",
                principalTable: "UsuarioCursoNivel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoNivel_CursoContent_CursoContentId",
                table: "CursoNivel",
                column: "CursoContentId",
                principalTable: "CursoContent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoNivel_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                table: "CursoNivel",
                column: "UsuarioCursoNivelModelId",
                principalTable: "UsuarioCursoNivel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCadastro_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                table: "UsuarioCadastro",
                column: "UsuarioCursoNivelModelId",
                principalTable: "UsuarioCursoNivel",
                principalColumn: "Id");
        }
    }
}
