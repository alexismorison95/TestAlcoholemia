using Backend.Application.Equipos.DTOs;
using Backend.Application.Equipos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class EquipoController : ControllerBase
    {
        private readonly IEquipoService iEquipoService;

        public EquipoController(IEquipoService pEquipoService)
        {
            iEquipoService = pEquipoService;
        }

        [HttpGet]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> GetEquipos()
        {
            IEnumerable<EquipoDTO> mEquipoList = await iEquipoService.GetEquipos();

            return Ok(mEquipoList);
        }

        [HttpPost]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> InsertEquipo([FromBody] EquipoDTO pEquipo)
        {
            EquipoDTO mEquipo = await iEquipoService.InsertEquipo(pEquipo);

            return Ok(mEquipo);
        }

        [HttpPut]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> UpdateEquipo([FromBody] EquipoDTO pEquipo)
        {
            EquipoDTO mEquipo = await iEquipoService.UpdateEquipo(pEquipo);

            return Ok(mEquipo);
        }

        [HttpDelete("{pEquipoId}")]
        [Authorize(Roles = "administrador")]
        public async Task<IActionResult> DeleteEquipo(int pEquipoId)
        {
            EquipoDTO? mEquipo = await iEquipoService.DeleteEquipo(pEquipoId);

            if (mEquipo != null)
            {
                return Ok(mEquipo);
            }

            return NotFound(new { detail = "Equipo no encontrado" });
        }
    }
}
