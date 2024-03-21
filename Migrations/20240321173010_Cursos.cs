using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Cursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioCursoNivelModelId",
                table: "UsuarioCadastro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CursoContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urlVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCursoNivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCursoNivel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CursoDados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CursoContentId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCursoNivelModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoDados_CursoContent_CursoContentId",
                        column: x => x.CursoContentId,
                        principalTable: "CursoContent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CursoDados_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                        column: x => x.UsuarioCursoNivelModelId,
                        principalTable: "UsuarioCursoNivel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CursoNivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CursoContentId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCursoNivelModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoNivel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoNivel_CursoContent_CursoContentId",
                        column: x => x.CursoContentId,
                        principalTable: "CursoContent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CursoNivel_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                        column: x => x.UsuarioCursoNivelModelId,
                        principalTable: "UsuarioCursoNivel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCadastro_UsuarioCursoNivelModelId",
                table: "UsuarioCadastro",
                column: "UsuarioCursoNivelModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDados_CursoContentId",
                table: "CursoDados",
                column: "CursoContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDados_UsuarioCursoNivelModelId",
                table: "CursoDados",
                column: "UsuarioCursoNivelModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoNivel_CursoContentId",
                table: "CursoNivel",
                column: "CursoContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoNivel_UsuarioCursoNivelModelId",
                table: "CursoNivel",
                column: "UsuarioCursoNivelModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCadastro_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                table: "UsuarioCadastro",
                column: "UsuarioCursoNivelModelId",
                principalTable: "UsuarioCursoNivel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCadastro_UsuarioCursoNivel_UsuarioCursoNivelModelId",
                table: "UsuarioCadastro");

            migrationBuilder.DropTable(
                name: "CursoDados");

            migrationBuilder.DropTable(
                name: "CursoNivel");

            migrationBuilder.DropTable(
                name: "CursoContent");

            migrationBuilder.DropTable(
                name: "UsuarioCursoNivel");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioCadastro_UsuarioCursoNivelModelId",
                table: "UsuarioCadastro");

            migrationBuilder.DropColumn(
                name: "UsuarioCursoNivelModelId",
                table: "UsuarioCadastro");
        }
    }
}
