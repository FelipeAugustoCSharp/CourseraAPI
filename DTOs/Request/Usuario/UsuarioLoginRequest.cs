using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO.Request.Usuario
{
    public class UsuarioLoginRequest
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="O Campo {0} é Obrigatório.")]         
        [EmailAddress(ErrorMessage ="O Campo {0} é Inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="O Campo {0} é Obrigatório.")]   
        public string Senha { get; set; } = string.Empty;
    }
}