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

        #region Usuario
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            IEnumerable<UsuarioTipoUsuarioDTO> mUsuarioList = await iUsuarioService.GetUsuarios();

            return Ok(mUsuarioList);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUsuario([FromBody] UsuarioDTO pUsuario)
        {
            try
            {
                UsuarioDTO mUsuario = await iUsuarioService.InsertUsuario(pUsuario);

                return Ok(mUsuario);
            }
            catch (Exception)
            {
                return Problem("Error al insertar usuario", statusCode: 500);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] UsuarioDTO pUsuario)
        {
            try
            {
                UsuarioDTO mUsuario = await iUsuarioService.UpdateUsuario(pUsuario);

                return Ok(mUsuario);
            }
            catch (Exception)
            {
                return Problem("Error al actualizar usuario", statusCode: 500);
            }
            
        }

        [HttpDelete("{pNombreusuario}")]
        public async Task<IActionResult> DeleteUsuario(string pNombreusuario)
        {
            UsuarioDTO? mUsuario = await iUsuarioService.DeleteUsuario(pNombreusuario);

            if (mUsuario != null)
            {
                return Ok(mUsuario);
            }
            
            return NotFound(new { detail = "Usuario no encontrado" });
        }
        #endregion

        #region TipoUsuario
        [HttpGet]
        public async Task<IActionResult> GetTipoUsuarios()
        {
            IEnumerable<TipoUsuarioDTO> mTipoUsuarioList = await iUsuarioService.GetTipoUsuario();

            return Ok(mTipoUsuarioList);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTipoUsuario([FromBody] TipoUsuarioDTO pTipoUsuario)
        {
            try
            {
                TipoUsuarioDTO mTipoUsuario = await iUsuarioService.InsertTipoUsuario(pTipoUsuario);

                return Ok(mTipoUsuario);
            }
            catch (Exception)
            {
                return Problem("Error al insertar TipoUsuario", statusCode: 500);
            }

        }

        [HttpDelete("{pId}")]
        public async Task<IActionResult> DeleteTipoUsuario(int pId)
        {
            TipoUsuarioDTO? mTipoUsuario = await iUsuarioService.DeleteTipoUsuario(pId);

            if (mTipoUsuario != null)
            {
                return Ok(mTipoUsuario);
            }

            return NotFound(new { detail = "TipoUsuario no encontrado" });
        }
        #endregion
    }
}
