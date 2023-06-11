using APIRegisterCustomer.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace APIRegisterCustomer.Services
{
    public class TokenService
    {
        private static IConfiguration _configuration;

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static object GerarToken(User users)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtAuth:key").Value);

            var TokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UsuarioId", users.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public static int ObterUsuarioIdDoToken(string tokenString)
        {
            string token = tokenString.Replace("Bearer","");

            string[] tokennew = token.Split(" ");
            token = tokennew[1];

            var tokenHandler = new JwtSecurityTokenHandler();
            
            // Define a configuração para validar o token
            var tokenValidationParameters = new TokenValidationParameters
            { 
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("JwtAuth:key").Value)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                // Tenta validar e decodificar o token
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                // Verifica se o token é válido e contém as claims esperadas
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    // Obtém o valor do claim "UsuarioId" e converte para int
                    var usuarioIdClaim = claimsPrincipal.FindFirst("UsuarioId");
                    if (usuarioIdClaim != null && int.TryParse(usuarioIdClaim.Value, out var usuarioId))
                    {
                        return usuarioId;
                    }
                }
            }
            catch (Exception ex)
            {
                // Trate exceções de validação de token aqui
            }

            // Retorne um valor padrão ou lance uma exceção, dependendo do que for apropriado para o seu caso
            return 0;
        }
    }
}
