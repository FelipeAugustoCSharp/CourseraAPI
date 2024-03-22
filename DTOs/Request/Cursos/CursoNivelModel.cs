using System.ComponentModel.DataAnnotations;
using WebApi.Enums;

namespace WebApi.DTOs.Request.Cursos
{
    public class CursoNivelModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public EnumCursoNivel Nivel { get; set; }
    }
}
