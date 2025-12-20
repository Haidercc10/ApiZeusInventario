using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZeusInventarioWebAPI.Models;

namespace ZeusInventarioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class MaevendeController : ControllerBase
    {
        private readonly Data.InventarioDataContext _context;

        public MaevendeController(Data.InventarioDataContext context)
        {
            _context = context;
        }

        // Función para obtener los asesores de ventas activos
        [HttpGet("getActiveSales")]
        public ActionResult getActiveSales()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var sales = from v in _context.Set<Maevende>()
                        where v.Deshabilitado == 0
                        select new
                        {
                            Asesor_Id = v.Idvende,
                            Asesor = v.Nombvende,
                        }; 
            return Ok(sales);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

    }
}
