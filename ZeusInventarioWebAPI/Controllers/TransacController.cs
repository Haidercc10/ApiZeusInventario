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
        public async Task<ActionResult<Transac>> GetRecibosCaja(int id)
        {
            if (_context.Transacs == null) return NotFound();

            var transac = 

            if (transac == null) return BadRequest("No se encontraron recibos de caja en el rango de fechas consultado.");
            return transac;
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
