using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZeusInventarioWebAPI.Data;

namespace ZeusInventarioWebAPI.Controllers
{
    /// <summary>
    /// Verificación de conexión usada por el login de Plasticaribe antes de mostrar el formulario.
    /// Es anónimo a propósito: no devuelve datos, solo si la API y su base de datos responden.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController, AllowAnonymous]
    public class SaludController : ControllerBase
    {
        private readonly InventarioDataContext _context;
        public SaludController(InventarioDataContext context) { _context = context; }

        // GET: api/Salud -> 200 si la API y la base de datos responden, 503 si la base de datos no responde.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (await BaseDatosResponde()) return Ok(new { estado = "OK" });
            return StatusCode(StatusCodes.Status503ServiceUnavailable, new { estado = "SinBaseDatos" });
        }

        // Máximo 5 segundos para no dejar esperando la pantalla de login.
        private async Task<bool> BaseDatosResponde()
        {
            try
            {
                using var limite = CancellationTokenSource.CreateLinkedTokenSource(HttpContext.RequestAborted);
                limite.CancelAfter(TimeSpan.FromSeconds(5));
                return await _context.Database.CanConnectAsync(limite.Token);
            }
            catch { return false; }
        }
    }
}
