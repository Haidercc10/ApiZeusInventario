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
    public class ArticulosController : ControllerBase
    {
        private readonly Data.InventarioDataContext _context;

        public ArticulosController(Data.InventarioDataContext context)
        {
            _context = context;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        {
          if (_context.Articulos == null)
          {
              return NotFound();
          }
            return await _context.Articulos.ToListAsync();
        }

        
        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(decimal id)
        {
          if (_context.Articulos == null)
          {
              return NotFound();
          }
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        /** */
        [HttpGet("getArticulos/{item}")]
        public ActionResult GetArticulos2(string item)
        {

            var articulo = from ar in _context.Set<Articulo>()
                           where ar.Tipo == "PRODUCTO TERMINADO"
                           && ar.Nombre.Contains(item)
                           select new
                           {
                             ar.IdArticulo,
                             ar.Nombre
                           };     
            return Ok(articulo);
        }

        /** */
        [HttpGet("getVendedores/{nombre}")]
        public ActionResult GetVendedor2(string nombre)
        {
            var vendedor = from v in _context.Set<Maevende>()
                           where v.Deshabilitado != 1
                           && v.Nombvende.Contains(nombre)
                           select new
                           {
                               v.Idvende,
                               v.Nombvende
                           };
            return Ok(vendedor);

        }

        [HttpGet("getClientes/{nombre}")]
        public ActionResult GetCliente2(string nombre)
        {

            var clientes = from c in _context.Set<Cliente>()
                           where c.Deshabilitado != 1
                           && c.Razoncial.Contains(nombre)
                           select new
                           {
                               c.Idcliente, 
                               c.Razoncial
                           };
            
            return Ok(clientes);
        }


        // PUT: api/Articulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(decimal id, Articulo articulo)
        {
            if (id != articulo.IdArticulo)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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



        // POST: api/Articulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
          if (_context.Articulos == null)
          {
              return Problem("Entity set 'InventarioDataContext.Articulos'  is null.");
          }
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.IdArticulo }, articulo);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(decimal id)
        {
            if (_context.Articulos == null)
            {
                return NotFound();
            }
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticuloExists(decimal id)
        {
            return (_context.Articulos?.Any(e => e.IdArticulo == id)).GetValueOrDefault();
        }
    }
}
