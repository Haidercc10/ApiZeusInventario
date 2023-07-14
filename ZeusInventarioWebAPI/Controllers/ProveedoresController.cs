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
    public class ProveedoresController : ControllerBase
    {
        private readonly InventarioDataContext _context;

        public ProveedoresController(InventarioDataContext context)
        {
            _context = context;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedore>>> GetProveedores()
        {
          if (_context.Proveedores == null)
          {
              return NotFound();
          }
            return await _context.Proveedores.ToListAsync();
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedore>> GetProveedore(string id)
        {
          if (_context.Proveedores == null)
          {
              return NotFound();
          }
            var proveedore = await _context.Proveedores.FindAsync(id);

            if (proveedore == null)
            {
                return NotFound();
            }

            return proveedore;
        }

        // PUT: api/Proveedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedore(string id, Proveedore proveedore)
        {
            if (id != proveedore.Idprove)
            {
                return BadRequest();
            }

            _context.Entry(proveedore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedoreExists(id))
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

        // POST: api/Proveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proveedore>> PostProveedore(Proveedore proveedore)
        {
          if (_context.Proveedores == null)
          {
              return Problem("Entity set 'InventarioDataContext.Proveedores'  is null.");
          }
            _context.Proveedores.Add(proveedore);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProveedoreExists(proveedore.Idprove))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProveedore", new { id = proveedore.Idprove }, proveedore);
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedore(string id)
        {
            if (_context.Proveedores == null)
            {
                return NotFound();
            }
            var proveedore = await _context.Proveedores.FindAsync(id);
            if (proveedore == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedoreExists(string id)
        {
            return (_context.Proveedores?.Any(e => e.Idprove == id)).GetValueOrDefault();
        }
    }
}
