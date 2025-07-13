using DesafioFIAP.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioFIAP.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Criar o token para liberar o acesso aos endpoints protegidos
        /// </summary>
        /// <param name="loginDTO">Objeto login</param>
        /// <returns>Token criada</returns>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {

            if (loginDTO.Email == "admin@teste.com.br" && loginDTO.Senha == "123456")
            {
                var claims = new[]
                {
                        new Claim(ClaimTypes.Name, loginDTO.Email),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { token = tokenString });
            }

            return Unauthorized("Usuário ou senha inválidos.");
        }
    }
}