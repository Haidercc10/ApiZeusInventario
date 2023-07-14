
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
    public class EntradaController : ControllerBase
    {
        private readonly InventarioDataContext _context;

        public EntradaController(InventarioDataContext context)
        {
            _context = context;
        }

        // GET: api/Entrada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entradum>>> GetEntrada()
        {
          if (_context.Entrada == null)
          {
              return NotFound();
          }
            return await _context.Entrada.ToListAsync();
        }

        // GET: api/Entrada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entradum>> GetEntradum(decimal id)
        {
          if (_context.Entrada == null)
          {
              return NotFound();
          }
            var entradum = await _context.Entrada.FindAsync(id);

            if (entradum == null)
            {
                return NotFound();
            }

            return entradum;
        }

        // PUT: api/Entrada/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntradum(decimal id, Entradum entradum)
        {
            if (id != entradum.Consecutivo)
            {
                return BadRequest();
            }

            _context.Entry(entradum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradumExists(id))
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

        // POST: api/Entrada
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entradum>> PostEntradum(Entradum entradum)
        {
          if (_context.Entrada == null)
          {
              return Problem("Entity set 'InventarioDataContext.Entrada'  is null.");
          }
            _context.Entrada.Add(entradum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntradumExists(entradum.Consecutivo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntradum", new { id = entradum.Consecutivo }, entradum);
        }

        // DELETE: api/Entrada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntradum(decimal id)
        {
            if (_context.Entrada == null)
            {
                return NotFound();
            }
            var entradum = await _context.Entrada.FindAsync(id);
            if (entradum == null)
            {
                return NotFound();
            }

            _context.Entrada.Remove(entradum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntradumExists(decimal id)
        {
            return (_context.Entrada?.Any(e => e.Consecutivo == id)).GetValueOrDefault();
        }
    }
}
