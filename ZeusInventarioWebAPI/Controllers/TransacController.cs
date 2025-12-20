using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeusInventarioWebAPI.Data;
using ZeusInventarioWebAPI.Models;

namespace ZeusInventarioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class TransacController : ControllerBase
    {
        private readonly InventarioDataContext _context;

        public TransacController(InventarioDataContext context)
        {
            _context = context;
        }

        // GET: api/Transac
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transac>>> GetTransacs()
        {
          if (_context.Transacs == null)
          {
              return NotFound();
          }
            return await _context.Transacs.ToListAsync();
        }

        // GET: api/Transac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transac>> GetTransac(int id)
        {
          if (_context.Transacs == null)
          {
              return NotFound();
          }
            var transac = await _context.Transacs.FindAsync(id);

            if (transac == null)
            {
                return NotFound();
            }

            return transac;
        }

        // -- Obtener los recibos de caja de la empresa.
        [HttpGet("getRecibosCaja/{fecha1}/{fecha2}")]
        public ActionResult GetRecibosCaja(DateTime fecha1, DateTime fecha2)
        {
            if (_context.Transacs == null) return NotFound();

#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var transac = from t in _context.Set<Transac>()
                          from m in _context.Set<Maevende>()
                          from c in _context.Set<Cliente>()
                          where t.Nittra == c.Idcliente &&
                          t.Idvende == m.Idvende &&
                          t.Idfuente == "RC" &&
                          t.Tipofac == "FA" &&
                          t.Fgratra >= fecha1 &&
                          t.Fgratra <= fecha2
                          orderby t.Fgratra descending
                          select new
                          {
                              AnoMes = t.Anotra,
                              Fuente = t.Idfuente,
                              Documento = t.Numdoctra,
                              Consecutivo = t.Consecutra,
                              FechaTransac = t.Fechatra,
                              IdCliente = t.Nittra,
                              Cliente = c.Razoncial,
                              Descripcion = t.Descritra.Trim(),
                              Valor = t.Valortra,
                              Cuenta = t.Codicta.Trim(),
                              IdVendedor = t.Idvende,
                              Vendedor = m.Nombvende,
                              Factura = t.Numefac,
                              Vencimiento = t.Vencefac,
                              Usuario = t.Idusuario.Trim(),
                              FechaRegistro = t.Fgratra
                          };
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.

            if (transac == null) return BadRequest("No se encontraron recibos de caja en el rango de fechas consultado.");
            else return Ok(transac);
        }

        // GET: Valor Facturado el día de hoy.
        [HttpGet("ValorTotalFacturadoHoy")]
        public ActionResult ValorTotalFacturadoHoy()
        {
            DateTime Hoy = DateTime.Today;

            if (_context.FacturaDeClientes == null) return NotFound();
            var facturado = (from t in _context.Set<Transac>()
                             where t.Idfuente == "FV"
                             && t.Tipofac == "FA"
                             && t.Indcpitra == "1"
                             && t.Fechatra == Convert.ToString(Hoy.ToString("yyyy/MM/dd"))
                             select Math.Abs(t.Valortra)).Sum();

            var devuelto = (from t in _context.Set<Transac>()
                             where t.Idfuente == "DV"
                             && t.Idfuente == "NV"
                             && t.Tipofac == "FA"
                             && t.Indcpitra == "1"
                             && t.Fechatra == Convert.ToString(Hoy.ToString("yyyy/MM/dd"))
                            select t.Valortra).Sum();

            return Ok(facturado - devuelto);
        }

        [HttpGet("ValorTotalFacturadoHoy2")]
        public ActionResult ValorTotalFacturadoHoy2()
        {
            DateTime Hoy = DateTime.Today;

            if (_context.FacturaDeClientes == null) return NotFound();

            var ano = DateTime.Today;
            var mes = Convert.ToString(ano.Month).Length == 1 ? "0" + Convert.ToString(ano.Month) : Convert.ToString(ano.Month);

            var MovimientoItem = (from mi in _context.Set<MovimientoItem>()
                                  where mi.Fuente == "FV"
                                  && mi.Estado == "Procesado"
                                  && mi.FechaDocumento.Month == ano.Month
                                  && mi.FechaDocumento.Year == ano.Year
                                  && mi.FechaDocumento.Day == ano.Day
                                  && mi.Consecutivo != 35454
                                  //&& mi.Consecutivo != 38155
                                  select mi.PrecioTotal + mi.TotalDescuentoVenta).Sum(); 

            var arriendo = (from tr in _context.Set<Transac>()
                            where tr.Idfuente == "FV"
                            && tr.Tipofac == "FA"
                            && tr.Indcpitra == "1"
                            && tr.Codicta == Convert.ToString(422010)
                            && tr.Anotra == Convert.ToString(ano.Year) + Convert.ToString(mes)
                            && tr.Fechatra == Convert.ToString(Hoy.ToString("yyyy/MM/dd"))
                            && tr.Statustra == "AC"
                            select Math.Abs(tr.Valortra)).Sum();

            var Transaccion1 = (from tr in _context.Set<Transac>()
                                where tr.Idfuente == "DV"
                                && tr.Tipofac == "FA"
                                && tr.Indcpitra == "1"
                                && tr.Anotra == Convert.ToString(ano.Year) + Convert.ToString(mes)
                                && tr.Valortra > 0
                                && tr.Fechatra == Convert.ToString(Hoy.ToString("yyyy/MM/dd"))
                                && tr.Statustra == "AC"
                                select tr.Valortra).Sum();

            var descuentosDV = (from mv in _context.Set<MovimientoItem>()
                                where mv.FechaDocumento.Month == Convert.ToInt32(mes)
                                && mv.FechaDocumento.Month == ano.Month
                                && mv.FechaDocumento.Year == ano.Year
                                && mv.FechaDocumento.Day == ano.Day
                                && mv.Fuente == "DV"
                                && mv.Estado == "Procesado"
                                && mv.TipoDocumento == 26m
                                select mv.TotalDescuentoVenta).Sum();


            var Transaccion2 = (from tr in _context.Set<Transac>()
                                where tr.Idfuente == "NV"
                                && tr.Tipofac == "FA"
                                && tr.Indcpitra == "1"
                                && tr.Anotra == Convert.ToString(ano.Year) + Convert.ToString(mes)
                                && tr.Valortra > 0
                                && tr.Fechatra == Convert.ToString(Hoy.ToString("yyyy/MM/dd"))
                                && tr.Statustra == "AC"
                                select tr.Valortra).Sum();

            var datos = (MovimientoItem + arriendo) + ((Transaccion1 + Transaccion2) - descuentosDV);
            return Ok(datos);
        }



        // PUT: api/Transac/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransac(int id, Transac transac)
        {
            if (id != transac.Consecutra)
            {
                return BadRequest();
            }

            _context.Entry(transac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransacExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transac
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transac>> PostTransac(Transac transac)
        {
          if (_context.Transacs == null)
          {
              return Problem("Entity set 'InventarioDataContext.Transacs'  is null.");
          }
            _context.Transacs.Add(transac);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransac", new { id = transac.Consecutra }, transac);
        }

        // DELETE: api/Transac/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransac(int id)
        {
            if (_context.Transacs == null)
            {
                return NotFound();
            }
            var transac = await _context.Transacs.FindAsync(id);
            if (transac == null)
            {
                return NotFound();
            }

            _context.Transacs.Remove(transac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransacExists(int id)
        {
            return (_context.Transacs?.Any(e => e.Consecutra == id)).GetValueOrDefault();
        }
    }
}
