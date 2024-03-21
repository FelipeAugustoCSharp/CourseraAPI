using WebApi.DTO.Request;
using WebApi.DTO.Request.Usuario;
using WebApi.DTO.Response;

namespace WebApi.Interfaces
{
    public interface IUserService
    {
        Task<Response<UsuarioCadastroRequest>> Cadastrar(UsuarioCadastroRequest cadastro);
        Task<Response<UsuarioLoginRequest>> Login(UsuarioLoginRequest login);


    }
}