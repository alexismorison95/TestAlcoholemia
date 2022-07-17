using Backend.Application.DTOs.Login;
using Backend.Application.Interfaces;
using Backend.Core.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService iLoginService;

        public LoginController(ILoginService pLoginService)
        {
            iLoginService = pLoginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO pLoginDTO)
        {
            if (pLoginDTO is null)
            {
                return BadRequest("Petición inválida");
            }

            Usuario? mUsuario = await iLoginService.UserExists(pLoginDTO);

            if (mUsuario is null)
            {
                return Unauthorized(); 
            }
            else
            {
                var mClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, mUsuario.Tipousuario!.Tipo)
                };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKey@demo.com123456789"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7052/",
                    audience: "https://localhost:7052/",
                    claims: mClaims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new AuthenticationDTO { Token = tokenString });
            }
           
        }
    }
}
