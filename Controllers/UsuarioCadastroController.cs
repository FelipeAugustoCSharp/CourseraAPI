namespace WebApi.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using WebApi.DTO.Request;
    using WebApi.DTO.Request.Usuario;
    using WebApi.DTO.Response;
    using WebApi.Interfaces;
    using WebApi.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioCadastroController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public UsuarioCadastroController(IConfiguration conf, IUserService userService)
        {
            _config = conf;
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<ActionResult<Response<UsuarioCadastroRequest>>> CadastroUsuario([FromBody]UsuarioCadastroRequest usuarioCadastro)
        {
            Response<UsuarioCadastroRequest> response = new Response<UsuarioCadastroRequest>();
            response = await _userService.Cadastrar(usuarioCadastro);
            return  Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginRequest>> LoginUsuario([FromBody] UsuarioLoginRequest login)
        {
            Response<UsuarioLoginRequest> response = new Response<UsuarioLoginRequest>();
            response = await _userService.Login(login);
            return Ok(response);
        }
    }
}