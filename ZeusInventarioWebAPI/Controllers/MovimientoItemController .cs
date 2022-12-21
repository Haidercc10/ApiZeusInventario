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


        // Facturación mes actual.
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


        // GET: api/MovimientoItems/5
        [HttpGet("FacturacionTodosMeses/{mes}")]
        public ActionResult FacturacionTodosMeses(int mes)
        {
            if (_context.MovimientoItems == null)
            {
                return NotFound();
            }
            var ano = DateTime.Today;

            var MovimientoItem = (from mi in _context.Set<MovimientoItem>()
                                        where mi.Fuente == "FV"
                                        && mi.Estado == "Procesado"
                                        && mi.FechaDocumento.Month == mes
                                        && mi.FechaDocumento.Year == ano.Year
                                        select mi.PrecioTotal).Sum();

            var Transaccion1 = (from tr in _context.Set<Transac>()
                                        where tr.Idfuente == "DV"
                                        && tr.Tipofac == "FA"
                                        && tr.Indcpitra == "1"
                                        && tr.Fgratra.Month == mes
                                        && tr.Fgratra.Year == ano.Year
                                        select tr.Valortra).Sum();
            var datos = MovimientoItem - Transaccion1;

            return Ok(datos);
        }

        // GET: api/MovimientoItems/5
        [HttpGet("GetIvaVentaMensual/{fechaIni}/{fechaFin}")]
        public ActionResult GetIvaVentaMensual(DateTime fechaIni, DateTime fechaFin)
        {
            if (_context.MovimientoItems == null)
            {
                return NotFound();
            }
            var num1 = (from mov in _context.Set<MovimientoItem>()
                        where mov.Fuente == "FV"
                        && mov.Estado == "Procesado"
                        && mov.FechaDocumento >= fechaIni
                        && mov.FechaDocumento <= fechaFin
                        select mov.TotalIvaventas).Sum();

            var num2 = (from mov in _context.Set<MovimientoItem>()
                        where mov.Fuente == "DV"
                        && mov.Estado == "Procesado"
                        && mov.FechaDocumento >= fechaIni
                        && mov.FechaDocumento <= fechaFin
                        select mov.TotalIvaventas).Sum();

            var total = num1 - num2;
            return Ok(total);
        }


        // GET: api/MovimientoItems/5
        [HttpGet("GetIvaCompraMensual/{fechaIni}/{fechaFin}")]
        public ActionResult GetIvaCompraMensual(DateTime fechaIni, DateTime fechaFin)
        {
            if (_context.MovimientoItems == null)
            {
                return NotFound();
            }

            DateTime Hora1 = Convert.ToDateTime("00:00:00");
            DateTime Hora2 = Convert.ToDateTime("23:59:00");

            var num1 = (from mov in _context.Set<MovimientoItem>()
                        where (mov.Fuente == "EA" || mov.Fuente == "CC")
                        && mov.Estado == "Procesado"
                        && mov.FechaDocumento >= fechaIni.AddHours(Hora1.Hour).AddMinutes(Hora1.Minute).AddSeconds(Hora1.Second)
                        && mov.FechaDocumento <= fechaFin.AddHours(Hora1.Hour).AddMinutes(Hora1.Minute).AddSeconds(Hora1.Second)
                        select mov.TotalIvacompras).Sum();
            return Ok(num1);
        }


        // GET: api/MovimientoItems/5
        [HttpGet("GetIvaCompraTodosMeses/{mes}")]
        public ActionResult GetIvaCompraTodosMeses(int mes)
        {
            if (_context.MovimientoItems == null)
            {
                return NotFound();
            }
            var ano = DateTime.Today;

            DateTime Hora1 = Convert.ToDateTime("00:00:00");
            DateTime Hora2 = Convert.ToDateTime("23:59:00");

            var num1 = (from mov in _context.Set<MovimientoItem>()
                        where (mov.Fuente == "EA" || mov.Fuente == "CC")
                        && mov.Estado == "Procesado"
                        && mov.FechaDocumento.Month == mes
                        && mov.FechaDocumento.Year == ano.Year
                        select mov.TotalIvacompras).Sum();
            return Ok(num1);
        }
    }
}
