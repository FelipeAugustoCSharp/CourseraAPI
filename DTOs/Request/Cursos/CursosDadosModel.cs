using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO.Request.Cursos
{
    public class CursosDadosModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        [StringLength(50, ErrorMessage ="O Campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public string Photo { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public string Description { get; set; }
    }
}