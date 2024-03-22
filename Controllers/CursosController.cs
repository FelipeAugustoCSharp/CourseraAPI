namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.DTO.Request.Cursos;
    using WebApi.DTO.Response;
    using WebApi.DTOs.Request.Cursos;
    using WebApi.Enums;
    using WebApi.Interfaces;
    using WebApi.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoContent _cursoService;
        public CursosController(ICursoContent cS)
        {
            _cursoService = cS;
        }
        [HttpGet("buscar")]
        public async Task<ActionResult<Response<IEnumerable<CursoContent>>>> GetCursos()
        {
            Response<IEnumerable<CursoContent>> response = await _cursoService.ObterCursos();
            return Ok(response);
        }

        [HttpGet("banner")]
        public async Task<ActionResult<Response<IEnumerable<CursosDadosModel>>>> BannerCursos()
        {
            Response<IEnumerable<CursosDadosModel>> response = await _cursoService.BannerCursos();
            return Ok(response);
        }
        
        [HttpGet("{nivel}")]
        public async Task<ActionResult<Response<IEnumerable<CursoContent>>>> NivelCursos(int nivel)
        {
            Response<IEnumerable<CursoContent>> response = await _cursoService.NivelCursos(nivel);
            return Ok(response);
        }


    }
}