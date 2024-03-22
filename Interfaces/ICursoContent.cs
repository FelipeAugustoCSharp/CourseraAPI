using WebApi.DTO.Request.Cursos;
using WebApi.DTO.Response;
using WebApi.DTOs.Request.Cursos;
using WebApi.Enums;

namespace WebApi.Interfaces
{
    public interface ICursoContent
    {
        Task<Response<IEnumerable<CursoContent>>> ObterCursos();
        Task<Response<IEnumerable<CursosDadosModel>>> BannerCursos();
        Task<Response<IEnumerable<CursoContent>>> NivelCursos(int nivel);
    }
}
