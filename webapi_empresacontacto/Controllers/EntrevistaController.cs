using Microsoft.AspNetCore.Mvc;

namespace webapi_empresacontacto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntrevistaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var usuarioId = 1;
            return View(usuarioId);
        }





    }
}
