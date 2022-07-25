﻿using Backend.Application.Interfaces;
using Backend.Application.Usuarios.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> GetUsuarios()
        {
            IEnumerable<UsuarioDTO> mUsuarioList = await iUsuarioService.GetUsuarios();

            return Ok(mUsuarioList);
        }

        [HttpGet]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> GetUsuariosExtended()
        {
            IEnumerable<UsuarioExtendedDTO> mUsuarioList = await iUsuarioService.GetUsuariosExtended();

            return Ok(mUsuarioList);
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
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
        [Authorize(Roles = "administrador")]
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
        [Authorize(Roles = "administrador")]
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
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> GetTipoUsuarios()
        {
            IEnumerable<TipoUsuarioDTO> mTipoUsuarioList = await iUsuarioService.GetTipoUsuario();

            return Ok(mTipoUsuarioList);
        }
        #endregion
    }
}
