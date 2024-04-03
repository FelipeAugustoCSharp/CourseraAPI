using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApi.DTO.Request.Cursos;
using WebApi.Helper;

namespace WebApi.DTO.Request.Usuario
{

    public class UsuarioCadastroRequest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        [EmailAddress(ErrorMessage = "O Campo {0} é Inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="O Campo {0} é Obrigatório.")]
        [StringLength(50, ErrorMessage ="O Campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; } = string.Empty;


        [NotMapped]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        [Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais.")]
        public string ConfirmSenha { get; set; } = string.Empty;




    }
}