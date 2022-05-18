using Backend.Application.DTOs.Usuarios;
using Backend.Application.Interfaces;
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
        public async Task<IActionResult> InsertUsuario([FromBody] UsuarioDTO pUsuario)
        {
            UsuarioDTO mUsuario = await iUsuarioService.InsertUsuario(pUsuario);

            return Ok(mUsuario);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] UsuarioDTO pUsuario)
        {
            UsuarioDTO mUsuario = await iUsuarioService.UpdateUsuario(pUsuario);

            return Ok(mUsuario);
        }

        [HttpDelete("{pNombreusuario}")]
        public async Task<IActionResult> DeleteUsuario(string pNombreusuario)
        {
            UsuarioDTO? mUsuario = await iUsuarioService.DeleteUsuario(pNombreusuario);

            if (mUsuario != null)
            {
                return Ok(mUsuario);
            }
            
            return NotFound(new { Response = "Usuario no encontrado" });
        }
    }
}
