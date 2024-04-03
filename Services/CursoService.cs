using Microsoft.EntityFrameworkCore;
using WebApi.DTO.Request.Cursos;
using WebApi.DTO.Response;
using WebApi.DTOs.Request.Cursos;
using WebApi.Enums;
using WebApi.Infrastructure;
using WebApi.Interfaces;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace WebApi.Services
{
    public class CursoService : ICursoContent
    {
        private readonly DataContext _datacontext;
        private readonly ILogger<CursoService> _logger;

        public CursoService(DataContext context, ILogger<CursoService> logger)
        {
            _datacontext = context;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<CursoContent>>> ObterCursos()
        {
            Response<IEnumerable<CursoContent>> response = new Response<IEnumerable<CursoContent>>();

            try
            {
                List<CursoContent> cursoListados = _datacontext.CursoContent.ToList();
                if (cursoListados.Count <= 0)
                {
                    response.SetData(null);
                    response.SetMessage("Nenhum curso foi encontrado");
                    response.SetSuccess(false);
                    return response;
                }

                response.SetData(cursoListados);
                response.SetMessage("Cursos Encontrados");

                return response;
            }
            catch (Exception ex)
            {
                response.SetData(null);
                response.SetMessage("Erro ao encontrar cursos: " + ex);
                response.SetSuccess(false);
                return response;
            }
        }

        public async Task<Response<IEnumerable<CursosDadosModel>>> BannerCursos()
        {
            Response<IEnumerable<CursosDadosModel>> response = new Response<IEnumerable<CursosDadosModel>>();

            try
            {
                List<CursosDadosModel> cursoListados = _datacontext.CursoDados.ToList();
                if (cursoListados.Count <= 0)
                {
                    response.SetData(null);
                    response.SetMessage("Nenhum curso foi encontrado");
                    response.SetSuccess(false);
                    return response;
                }

                response.SetData(cursoListados);
                response.SetMessage("Curso Encontrado");

                return response;
            }
            catch (Exception ex)
            {
                response.SetData(null);
                response.SetMessage("Erro ao encontrar curso: " + ex);
                response.SetSuccess(false);
                return response;
            }
        }

        public async Task<Response<IEnumerable<CursoContent>>> NivelCursos(int nivel)
        {
            Response<IEnumerable<CursoContent>> response = new Response<IEnumerable<CursoContent>>();

            try
            {

                //Erro na lógica
                List<CursoContent> cursoListados = _datacontext.CursoContent.Where(x => x.CursoNivelId == nivel).ToList();

                if (cursoListados.Count <= 0)
                {
                    response.SetData(null);
                    response.SetMessage("Nenhum curso foi encontrado");
                    response.SetSuccess(false);
                    return response;
                }

                response.SetData(cursoListados);
                response.SetMessage("Curso Encontrado");

                return response;
            }
            catch (Exception ex)
            {
                response.SetData(null);
                response.SetMessage("Erro ao encontrar curso: " + ex);
                response.SetSuccess(false);
                return response;
            }

        }

        public async Task<Response<IEnumerable<UsuarioCursoNivelModel>>> InscreverCurso(UsuarioCursoNivelModel CursosUsuario)
        {
            Response<IEnumerable<UsuarioCursoNivelModel>> response = new Response<IEnumerable<UsuarioCursoNivelModel>>();

            try
            {
                if (CursosUsuario == null)
                {
                    response.SetData(null);
                    response.SetMessage("Ocorreu um erro ao salvar o curso");
                    response.SetSuccess(false);
                    return response;
                }

                //Query manual no banco de dados pois o 'add' está criando um novo valor em todas as tabelas associadas
                _logger.LogInformation(1, "Resposta: " + CursosUsuario.UsuarioId + " " + CursosUsuario.CursoDadosId + " " + CursosUsuario.CursoNivelId);
                string query = "INSERT INTO UsuarioCursoNivel (CursoDadosId, UsuarioId, CursoNivelId) VALUES ({0}, {1}, {2})";
                object[] parameters = { CursosUsuario.CursoDadosId, CursosUsuario.UsuarioId, CursosUsuario.CursoNivelId };
                await _datacontext.Database.ExecuteSqlRawAsync(query, parameters);

                var dados = _datacontext.UsuarioCursoNivel.ToList();
                response.SetData(dados);
                response.SetMessage("Curso adicionado com sucesso!");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao salvar curso");
                response.SetData(null);
                response.SetMessage("Ocorreu um erro ao salvar curso " + ex.Message);
                response.SetSuccess(false);
                return response;
            }
        }

        public async Task<Response<IEnumerable<UsuarioCursoNivelModel>>> ObterCursosUsuario(int usuarioId)
        {
            Response<IEnumerable<UsuarioCursoNivelModel>> response = new Response<IEnumerable<UsuarioCursoNivelModel>>();

            try
            {
                if(usuarioId == 0 || usuarioId == null)
                {
                    response.SetData(null);
                    response.SetMessage("Cursos não encontrados");
                    response.SetSuccess(false);
                    return response;
                }

                string query =("SELECT * FROM UsuarioCursoNivel WHERE UsuarioId = {0}");
                var result = await _datacontext.UsuarioCursoNivel.FromSqlRaw(query, usuarioId).ToListAsync();

                response.SetData(result);
                response.SetMessage("Curso Encontrado");
                return response;
            }
            catch(Exception ex)
            {
                response.SetData(null);
                response.SetMessage("Ocorreu um erro ao encontrar cursos: " + ex.Message);
                response.SetSuccess(false);
                return response;
                return response;
            }

            
        }
    }
}
