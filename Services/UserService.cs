using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApi.DTO.Request.Usuario;
using WebApi.DTO.Response;
using WebApi.Helper;
using WebApi.Infrastructure;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _datacontext;
        private readonly IConfiguration _configuration;
        public UserService(DataContext dataContext, IConfiguration conf)
        {
            _datacontext = dataContext;
            _configuration = conf;
        }

        public async Task<Response<UsuarioCadastroRequest>> Cadastrar(UsuarioCadastroRequest cadastro)
        {
            Response<UsuarioCadastroRequest> response = new Response<UsuarioCadastroRequest>();

            if (cadastro == null || cadastro.Senha != cadastro.ConfirmSenha)
            {
                response.SetData(null);
                response.SetMessage("Erro ao cadastrar, verifique todos os campos.");
                response.SetSuccess(false);
                return response;
            }

            try
            {              
                var UserExists = await _datacontext.UsuarioCadastro.FirstOrDefaultAsync(x => x.Email  == cadastro.Email);
                if (UserExists != null) 
                {
                    response.SetData(null);
                    response.SetMessage("Erro ao cadastrar, o Usuario J� Existe. ");
                    response.SetSuccess(false);
                    return response;              
                }
                cadastro.Senha = cadastro.Senha.GerarHash();
                _datacontext.UsuarioCadastro.Add(cadastro);
                await _datacontext.SaveChangesAsync();

                response.SetData(cadastro);
                response.SetMessage($"Cadastro realizado com sucesso: {cadastro.Id}.");
                

            }
            catch (Exception ex)
            {
                response.SetMessage($"Erro ao cadastrar: {ex.Message}");
                response.SetSuccess(false);
            }

            return response;
        }

        public async Task<Response<UsuarioLoginRequest>> Login(UsuarioLoginRequest login)
        {
            Response<UsuarioLoginRequest> response = new Response<UsuarioLoginRequest>();
            try
            {
                var usuario =  await _datacontext.UsuarioCadastro.FirstOrDefaultAsync(user => user.Email == login.Email);
                login.Senha = login.Senha.GerarHash();

                if (
                    usuario.Email != login.Email ||
                    usuario.Senha != login.Senha ||
                    usuario == null || 
                    login == null ||
                    login.Senha.Length < 6                     
                    )
                {
                    response.SetData(null);
                    response.SetMessage("Erro ao fazer o Login. Verifique as suas credenciais");
                    response.SetSuccess(false);
                    return response;
                }

                

                if (login.Senha == usuario.Senha)
                {
                    GerarToken gerarToken = new GerarToken(_configuration, login);
                    login.Id = usuario.Id;

                    response.SetToken(gerarToken.GenerateToken());
                    response.SetRefreshToken(gerarToken.RefreshToken());

                    response.SetData(login);
                    response.SetMessage($"Usuario logado com sucesso!");
                }
                else
                {
                    response.SetData(null);
                    response.SetMessage($"Erro ao Logar, tente novamente!");
                    response.SetSuccess(false);
                }
            }
            catch (Exception ex)
            {
                response.SetMessage($"Erro ao cadastrar: {ex.Message}");
                response.SetSuccess(false);
            }

            return response;
        }
    }
}