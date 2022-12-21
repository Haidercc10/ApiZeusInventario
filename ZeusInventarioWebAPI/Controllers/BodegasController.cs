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
    public class BodegasController : ControllerBase
    {
        private readonly Data.InventarioDataContext _context;

        public BodegasController(Data.InventarioDataContext context)
        {
            _context = context;
        }

        // GET: api/Bodegas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodegas()
        {
          if (_context.Bodegas == null)
          {
              return NotFound();
          }
            return await _context.Bodegas.ToListAsync();
        }

        // GET: api/Bodegas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bodega>> GetBodega(string id)
        {
          if (_context.Bodegas == null)
          {
              return NotFound();
          }
            var bodega = await _context.Bodegas.FindAsync(id);

            if (bodega == null)
            {
                return NotFound();
            }

            return bodega;
        }

        // PUT: api/Bodegas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodega(string id, Bodega bodega)
        {
            if (id != bodega.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(bodega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodegaExists(id))
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

        // POST: api/Bodegas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bodega>> PostBodega(Bodega bodega)
        {
          if (_context.Bodegas == null)
          {
              return Problem("Entity set 'InventarioDataContext.Bodegas'  is null.");
          }
            _context.Bodegas.Add(bodega);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BodegaExists(bodega.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBodega", new { id = bodega.Codigo }, bodega);
        }

        // DELETE: api/Bodegas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodega(string id)
        {
            if (_context.Bodegas == null)
            {
                return NotFound();
            }
            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }

            _context.Bodegas.Remove(bodega);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BodegaExists(string id)
        {
            return (_context.Bodegas?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
