using WebApi.DTO.Request.Cursos;
using WebApi.DTO.Response;
using WebApi.DTOs.Request.Cursos;
using WebApi.Enums;
using WebApi.Infrastructure;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class CursoService : ICursoContent
    {
        private readonly DataContext _datacontext;

        public CursoService(DataContext context)
        {
            _datacontext = context;
        }
        public async Task<Response<IEnumerable<CursoContent>>> ObterCursos()
        {
            Response<IEnumerable<CursoContent>> response = new Response<IEnumerable<CursoContent>>();

            try
            {
                List<CursoContent> cursoListados = _datacontext.CursoContent.ToList();
                if(cursoListados.Count <= 0) 
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
            catch(Exception ex) 
            {
                response.SetData(null);
                response.SetMessage("Erro ao encontrar cursos: "+ex );
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
                response.SetMessage("Erro ao encontrar curso: "+ ex);
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
                response.SetMessage("Erro ao encontrar curso: "+ ex);
                response.SetSuccess(false);
                return response;
            }
        }



    }
}
