using System.ComponentModel.DataAnnotations;
using WebApi.DTO.Request.Cursos;

namespace WebApi.DTOs.Request.Cursos
{
    public class CursoContent
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public int CursoNivelId { get; set; }
        public CursoNivelModel CursoNivel { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public int CursoDadosId { get; set; }
        public CursosDadosModel CursoDados { get; set; }

        public string? urlVideo { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public string Conteudo { get; set; }
    }
}