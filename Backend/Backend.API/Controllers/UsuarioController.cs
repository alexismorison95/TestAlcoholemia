using Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
            var mUsuarioList = await iUsuarioService.GetUsers();

            return Ok(mUsuarioList);
        }
    }
}
