using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.DTO.Request.Cursos;
using WebApi.DTO.Request.Usuario;

namespace WebApi.DTOs.Request.Cursos
{
    public class UsuarioCursoNivelModel
    {
        [Key]
        public int Id { get; set; }

        public int CursoDadosId { get; set; }
        public CursosDadosModel CursoDados { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioCadastroRequest Usuario { get; set; }

        public int CursoNivelId { get; set; }
        public CursoNivelModel CursoNivel { get; set; }

    }
}
