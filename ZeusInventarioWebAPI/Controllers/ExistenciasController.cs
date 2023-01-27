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
    public class ExistenciasController : ControllerBase
    {
        private readonly Data.InventarioDataContext _context;

        public ExistenciasController(Data.InventarioDataContext context)
        {
            _context = context;
        }

        // GET: api/Existencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Existencia>>> GetExistencia()
        {
          if (_context.Existencia == null)
          {
              return NotFound();
          }
            return await _context.Existencia.ToListAsync();
        }

        //GET EXISTENCIA Y ARTICULO PARA OBTENER INVENTARIO
        [HttpGet("BusquedaCodigoArticulo")]
        public IActionResult GetExistenciasProductos()
        {
            if (_context.Existencia == null)
            {
                return NotFound();
            }

            var TipoProd = "PRODUCTO TERMINADO";
            var Bodega = "003";
            var CodArticulo = _context.Existencia.Where(a => a.ArticuloNavigation.Tipo == TipoProd
                                                && a.Bodega == Bodega
                                                && a.Existencias >= 1
                                                && a.Articulo == a.ArticuloNavigation.IdArticulo)
                                               .Include(a => a.ArticuloNavigation)
                                               .OrderByDescending(x => x.Existencias)
                                               .Select(ART => new {
                                                   ART.Articulo,
                                                   ART.ArticuloNavigation.Codigo,
                                                   ART.ArticuloNavigation.Nombre,
                                                   ART.Existencias,
                                                   ART.ArticuloNavigation.PrecioVenta,
                                                   ART.ArticuloNavigation.Presentacion,
                                                   Precio_Total = ART.Existencias * ART.ArticuloNavigation.PrecioVenta
                                               }).ToList();

            if (CodArticulo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(CodArticulo);
            }
        }

        //
        [HttpGet("getExistenciasArticulo/{id}")]
        public ActionResult getExistenciasArticulo(string id)
        {
            var con = from exis in _context.Set<Existencia>()
                      from art in _context.Set<Articulo>()
                      where exis.Articulo == art.IdArticulo
                            && art.Codigo == id
                      select exis;
            return Ok(con);
        }

        //
        [HttpGet("getPrecioUltimoPrecioFacturado/{producto}/{presentacion}")]
        public ActionResult getPrecioUltimoPrecioFacturado(string producto, string presentacion)
        {
            var con = (from ped in _context.Set<MovimientoItem>()
                      where presentacion == ped.Presentacion
                            && producto == ped.CodigoArticulo
                            && ped.TipoDocumento == 9
                      orderby ped.FechaDocumento descending
                      select ped.PrecioUnidad).FirstOrDefault();
            return Ok(con);
        }

        // GET: api/Existencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Existencia>> GetExistencia(decimal id)
        {
          if (_context.Existencia == null)
          {
              return NotFound();
          }
            var existencia = await _context.Existencia.FindAsync(id);

            if (existencia == null)
            {
                return NotFound();
            }

            return existencia;
        }

        // PUT: api/Existencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExistencia(decimal id, Existencia existencia)
        {
            if (id != existencia.Articulo)
            {
                return BadRequest();
            }

            _context.Entry(existencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExistenciaExists(id))
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

        // POST: api/Existencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Existencia>> PostExistencia(Existencia existencia)
        {
          if (_context.Existencia == null)
          {
              return Problem("Entity set 'InventarioDataContext.Existencia'  is null.");
          }
            _context.Existencia.Add(existencia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExistenciaExists(existencia.Articulo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExistencia", new { id = existencia.Articulo }, existencia);
        }

        // DELETE: api/Existencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExistencia(decimal id)
        {
            if (_context.Existencia == null)
            {
                return NotFound();
            }
            var existencia = await _context.Existencia.FindAsync(id);
            if (existencia == null)
            {
                return NotFound();
            }

            _context.Existencia.Remove(existencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExistenciaExists(decimal id)
        {
            return (_context.Existencia?.Any(e => e.Articulo == id)).GetValueOrDefault();
        }
    }
}
