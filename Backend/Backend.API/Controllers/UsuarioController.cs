using Backend.Application.DTOs.Usuarios;
using Backend.Application.Interfaces;
using Backend.Core.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService iUsuarioService;

        public UsuarioController(IUsuarioService pUsuarioService)
        {
            iUsuarioService = pUsuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            IEnumerable<GetUsuarioDTO> mUsuarioList = await iUsuarioService.GetUsuarios();

            return Ok(mUsuarioList);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuario([FromBody] UsuarioDTO pUsuario)
        {
            Usuario mUsuario = await iUsuarioService.InsertUsuario(pUsuario);

            return Ok(mUsuario);
        }
    }
}
