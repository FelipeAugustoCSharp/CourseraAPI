using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.DTO.Request;
using WebApi.DTO.Request.Usuario;

namespace WebApi.Helper
{
    public class GerarToken
    {
        private readonly IConfiguration _configuration;
        public GerarToken(IConfiguration conf)
        {
            _configuration = conf;
        }
        public string GenerateToken(UsuarioLoginRequest user)
        {
            
            var handle = new JwtSecurityTokenHandler();

            var Key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GerarClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2)
            };

            var token = handle.CreateToken(tokenDescriptor);

            return handle.WriteToken(token);
        }

        private static ClaimsIdentity GerarClaims(UsuarioLoginRequest user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            return ci;
        }
    }

}
