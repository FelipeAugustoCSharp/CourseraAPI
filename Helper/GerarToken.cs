using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.DTO.Request;
using WebApi.DTO.Request.Usuario;
using WebApi.DTOs.Response;

namespace WebApi.Helper
{
    public class GerarToken
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioLoginRequest _user;
        public GerarToken(IConfiguration configuration, UsuarioLoginRequest user)
        {
            _configuration = configuration;
            _user = user;
        }

        public string GenerateToken()
        {
            var handle = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = handle.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _configuration.GetSection("Jwt:Issuer").Value,
                Audience = _configuration.GetSection("Jwt:Audience").Value,
                NotBefore = DateTime.Now,
                Subject = GerarClaims(_user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddMinutes(60),
                IssuedAt = DateTime.UtcNow,
                TokenType = "at+jwt"
            });

            return handle.WriteToken(token);
        }

        public string RefreshToken()
        {
            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Sub, _user.Id.ToString()) };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var handle = new JwtSecurityTokenHandler();

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature);

            var securityToken = handle.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _configuration.GetSection("Jwt:Issuer").Value,
                Audience = _configuration.GetSection("Jwt:Audience").Value,
                NotBefore = DateTime.Now,
                Subject = identityClaims,
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddMinutes(60),
                TokenType = "rt+jwt"
            });

            var encodedJwt = handle.WriteToken(securityToken);
            return encodedJwt;
        }

        public ClaimsPrincipal ValidateToken(string isValidToken)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration.GetSection("Jwt:Issuer").Value,
                ValidAudience = _configuration.GetSection("Jwt:Audience").Value,
                IssuerSigningKey = key
            };

            var handler = new JwtSecurityTokenHandler();
            return handler.ValidateToken(isValidToken, parameters, out _);
        }

        public string GetClaimValueFromToken(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"])),
                ValidateLifetime = false
            }, out _);

            var claim = ((ClaimsIdentity)principal.Identity).FindFirst(claimType);

            return claim?.Value;
        }


        public async Task<TokensResponse> NewRefreshToken(string tokenAtual, string expiredToken)
        {
            TokensResponse tokens = new TokensResponse();

            var tokenAntigo = RefreshToken();
            if (tokenAntigo != tokenAtual)
            {
                throw new Exception("Invalid refresh token");
            }

            var newAccessToken = GenerateToken();
            var newRefreshToken = RefreshToken();
            tokens.Tokem = newAccessToken;
            tokens.RefreshToken = newRefreshToken;

            return tokens;
        }

        private static ClaimsIdentity GerarClaims(UsuarioLoginRequest user)
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            return identity;
        }
    }
}
