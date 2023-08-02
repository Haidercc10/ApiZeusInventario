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
    public class FacturaDeClienteController : ControllerBase
    {
        private readonly Data.InventarioDataContext _context;

        public FacturaDeClienteController(Data.InventarioDataContext context)
        {
            _context = context;
        }

        // GET: api/Factura de Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDeCliente>>> GetFacturasDeClientes()
        {
          if (_context.FacturaDeClientes == null)
          {
              return NotFound();
          }
            return await _context.FacturaDeClientes.ToListAsync();
        }

        
        // GET: api/Factura de Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaDeCliente>> GetFacturaDeCliente(decimal id)
        {
          if (_context.FacturaDeClientes == null)
          {
              return NotFound();
          }
            var factura = await _context.FacturaDeClientes.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }


        // GET: Valor Facturado el día de hoy.
        [HttpGet("ValorFacturadoHoy")]
        public ActionResult GetFacturado()
        {
            DateTime Hoy = DateTime.Today;

            if (_context.FacturaDeClientes == null) return NotFound();
            var facturado = (from FV in _context.Set<FacturaDeCliente>()
                            from DI in _context.Set<DocumentoItem>()
                            where FV.Consecutivo == DI.Documento &&
                            FV.Fecha == Hoy
                            select DI.PrecioTotal).Sum();
            return Ok(facturado);
        }


        // PUT: api/Factura de Cliente/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaDeCliente(decimal id, FacturaDeCliente FacturaCliente)
        {
            if (id != FacturaCliente.Consecutivo)
            {
                return BadRequest();
            }

            _context.Entry(FacturaCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaDeClienteExists(id))
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



        // POST: api/Factura de Cliente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaDeCliente>> PostFacturaDeCliente(FacturaDeCliente Factura)
        {
          if (_context.FacturaDeClientes == null)
          {
              return Problem("Entity set 'InventarioDataContext.FacturaDeClientes'  is null.");
          }
            _context.FacturaDeClientes.Add(Factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturaDeCliente", new { id = Factura.Consecutivo }, Factura);
        }

        // DELETE: api/Factura de Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaDeCliente(decimal id)
        {
            if (_context.FacturaDeClientes == null)
            {
                return NotFound();
            }
            var factura = await _context.FacturaDeClientes.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.FacturaDeClientes.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaDeClienteExists(decimal id)
        {
            return (_context.FacturaDeClientes?.Any(e => e.Consecutivo == id)).GetValueOrDefault();
        }
    }
}
