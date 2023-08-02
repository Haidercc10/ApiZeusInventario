using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZeusInventarioWebAPI.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConfigurationManager = ZeusInventarioWebAPI.Service.ConfigurationManager;

namespace PlasticaribeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ZeusInventarioWebAPI.Data.InventarioDataContext _context;

        public AuthenticationController(ZeusInventarioWebAPI.Data.InventarioDataContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            if (user.Id_Usuario == 123456798 && user.Contrasena == "")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                    audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddHours(24),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse { 
                    Usuario = "Admin",
                    Token = tokenString 
                });
            }
            return Unauthorized();
#pragma warning restore CS8604 // Posible argumento de referencia nulo
        }
    }
}
