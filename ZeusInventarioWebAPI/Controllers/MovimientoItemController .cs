using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeusInventarioWebAPI.Data;
using ZeusInventarioWebAPI.Models;

namespace ZeusInventarioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoItemsController : ControllerBase
    {
        private readonly Data.InventarioDataContext _context;

        public MovimientoItemsController(Data.InventarioDataContext context)
        {
            _context = context;
        }

        // GET: api/MovimientoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoItem>>> GetMovimientoItems()
        {
          if (_context.MovimientoItems == null)
          {
              return NotFound();
          }
            return await _context.MovimientoItems.ToListAsync();
        }


        // GET: api/MovimientoItems/5
        [HttpGet("FacturacionMensual/{fechaIni}/{fechaFin}")]
        public ActionResult GetMovimientoItem(DateTime fechaIni, DateTime fechaFin)
        {
            if (_context.MovimientoItems == null)
            {
                return NotFound();
            }
            var MovimientoItem = (from mi in _context.Set<MovimientoItem>()
                                  where mi.Fuente == "FV"
                                  && mi.Estado == "Procesado"
                                  && mi.FechaDocumento >= fechaIni
                                  && mi.FechaDocumento <= fechaFin
                                  select mi.PrecioTotal).Sum();

            var Transaccion1 = (from tr in _context.Set<Transac>()
                               where tr.Idfuente == "DV"
                               && tr.Tipofac == "FA"
                               && tr.Indcpitra == "1"
                               && tr.Fgratra >= fechaIni
                               && tr.Fgratra <= fechaFin
                               select tr.Valortra).Sum();

            //if (MovimientoItem == null) MovimientoItem = 0;
            //if (Transaccion == null) Transaccion = 0;

            var ValorReal = MovimientoItem - Transaccion1;

            return Ok(ValorReal);
        }



       
    }
}
