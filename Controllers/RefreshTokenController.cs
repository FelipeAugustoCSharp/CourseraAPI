using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Response;
using WebApi.Helper;

namespace WebApi.Controllers
{
    public class RefreshTokenController : ControllerBase
    {
        private readonly GerarToken _token;
        public RefreshTokenController(GerarToken refreshTokenService)
        {
            _token = refreshTokenService;
        }

        //[HttpPost]
        //[Route("refresh-token")]
        //public async Task<ActionResult<TokensResponse>> RefreshToken(string refreshToken,string expiredToken)
        //{
        //    try
        //    {
        //        var result = _token.NewRefreshToken(refreshToken, expiredToken);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
