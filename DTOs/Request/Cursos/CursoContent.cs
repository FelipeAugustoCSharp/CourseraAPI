using System.ComponentModel.DataAnnotations;
using WebApi.DTO.Request.Cursos;

namespace WebApi.DTOs.Request.Cursos
{
    public class CursoContent
    {
        [Key]
        public int Id { get; set; }

        // Remova a propriedade IdCurso daqui
        // public List<CursosDadosModel> IdCurso { get; set; }

        //[Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        //public int IdCursoId { get; set; } // Adicione a chave estrangeira de IdCurso

        //[Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public int CursoNivelId { get; set; }
        public CursoNivelModel CursoNivel { get; set; }

        public int CursoDadosId { get; set; }
        public CursosDadosModel CursoDados { get; set; }

        public string? urlVideo { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public string Conteudo { get; set; }
    }
}