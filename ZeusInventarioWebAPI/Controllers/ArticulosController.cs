using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZeusInventarioWebAPI.Models;

namespace ZeusInventarioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
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

        [HttpGet("getItemsByName/{name}")]
        public async Task<ActionResult> GetItemsByName(string name)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var items = await (from a in _context.Set<Articulo>().AsNoTracking()
                               where a.Tipo == "PRODUCTO TERMINADO" &&
                               a.Nombre.Contains(name)
                               select new
                               {
                                   Codigo = a.Codigo,
                                   Nombre = a.Nombre,
                               }).ToListAsync();
            return Ok(items);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        [HttpGet("getItemsByNumber/{item}")]
        public async Task<ActionResult> GetItemsByNumber(string item)
        {
            var items = await (from a in _context.Set<Articulo>().AsNoTracking()
                               where a.Tipo == "PRODUCTO TERMINADO" &&
                               a.Codigo == item
                               select new { 
                                    Codigo = a.Codigo,
                                    Nombre = a.Nombre,
                               }).ToListAsync();
            return Ok(items);
        }

        /** */
        [HttpGet("getArticulos/{item}")]
        public async Task<ActionResult> GetArticulos2(string item)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var articulo = await (from ar in _context.Set<Articulo>().AsNoTracking()
                           where ar.Tipo == "PRODUCTO TERMINADO"
                           && ar.Nombre.Contains(item)
                           select new
                           {
                               ar.IdArticulo,
                               ar.Codigo,
                               ar.Nombre
                           }).ToListAsync();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(articulo);
        }

        /** */
        [HttpGet("getArticulosxId/{codigo}")]
        public async Task<ActionResult> GetArticulosxId(string codigo)
        {
            var articulo = await (from ar in _context.Set<Articulo>().AsNoTracking()
                                  where ar.Tipo == "PRODUCTO TERMINADO"
                           && ar.Codigo == codigo
                           select new
                           {
                               ar.IdArticulo,
                               ar.Codigo,
                               ar.Nombre
                           }).ToListAsync();
            return Ok(articulo);
        }

        /**  */
        [HttpGet("getVendedores/{nombre}")]
        public async Task<ActionResult> GetVendedor2(string nombre)
        {
            var vendedor = await (from v in _context.Set<Maevende>().AsNoTracking()
                                  where v.Deshabilitado != 1
                           && v.Nombvende.Contains(nombre)
                           select new
                           {
                               v.Idvende,
                               v.Nombvende
                           }).ToListAsync();

            return Ok(vendedor);
        }

        [HttpGet("getVendedoresxId/{idvende}")]
        public async Task<ActionResult> GetNombreVendedor2(string idvende)
        {
            var vendedor = (from v in _context.Set<Maevende>().AsNoTracking()
                           where v.Deshabilitado != 1
                           && v.Idvende == idvende
                           select new
                           {
                               v.Idvende,
                               v.Nombvende
                           }).ToListAsync();

            return Ok(vendedor);
        }

        [HttpGet("getClientes/{nombre}")]
        public async Task<ActionResult> GetCliente2(string nombre)
        {
            var clientes = (from c in _context.Set<Cliente>().AsNoTracking()
                            where c.Deshabilitado != 1
                           && c.Razoncial.Contains(nombre)
                           select new
                           {
                               c.Idcliente,
                               c.Razoncial
                           }).ToListAsync();

            return Ok(clientes);
        }

        //Función para obtener clientes por idCliente
        [HttpGet("getClientesxId/{idCliente}")]
        public async Task<ActionResult> GetClientexId(string idCliente)
        {
            var clientes = await (from c in _context.Set<Cliente>().AsNoTracking()
                                  where c.Deshabilitado != 1
                                  && c.Idcliente == idCliente
                                  select new
                                  {
                                      c.Idcliente,
                                      c.Razoncial
                                  }).ToListAsync();

            return Ok(clientes);
        }

        //Función para obtener clientes por idVendedor
        [HttpGet("getClientesxVendedor/{idVendedor}")]
        public async Task<ActionResult> GetCliente_Vendedor(string idVendedor)
        {

            var clientes = await (from c in _context.Set<Cliente>().AsNoTracking()
                                  where c.Deshabilitado != 1
                                  && c.Idvende == idVendedor
                                  select new
                                  {
                                      c.Idcliente,
                                      c.Razoncial
                                  }).ToListAsync();

            return Ok(clientes);
        }

        //Función para obtener clientes por idVendedor y nombre
        [HttpGet("getCliente_Vendedor_LikeNombre/{idVendedor}/{nombre}")]
        public async Task<ActionResult> GetCliente_Vendedor_LikeNombre(string idVendedor, string nombre)
        {

            var clientes = await (from c in _context.Set<Cliente>()
                           where c.Deshabilitado != 1
                           && c.Idvende == idVendedor
                           && c.Razoncial.Contains(nombre)
                           select new
                           {
                               c.Idcliente,
                               c.Razoncial
                           }).ToListAsync();

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

        //Función para insertar un artículo en la base de datos mediante parámetros en la URL
        [HttpGet("insertarArticulo/{Codigo}/{Nombre}/{Grupo}/{Presentacion}/{Tipo}/{Valorizacion}/{Categoria}/{PrecioVenta}/{Iva}")]
        public ActionResult PostArticulo2(string Codigo, string Nombre, string Grupo, string Presentacion, string Tipo, string Valorizacion, string Categoria, decimal PrecioVenta, decimal Iva)
        {
            if (_context.Articulos == null) return Problem("Entity set 'InventarioDataContext.Articulos'  is null.");

            var insert = _context.Database.ExecuteSql($"INSERT INTO [dbo].[Articulo] ([Codigo] ,[Nombre] ,[Descripcion] ,[Grupo] ,[GrupoAuxiliar] ,[Presentacion] ,[Tipo] ,[Valorización] ,[Categoria] ,[PorcentajeIva] ,[CuentaIVA] ,[PrecioVenta] ,[DescripcionOtroIdioma] ,[ComplementoCosto] ,[DesHabilitado] ,[DiasGarantia] ,[ComplementoVenta] ,[ConfiguracionPrecioVenta] ,[ComplementoInventario] ,[ComplementoDevolucionVentas1] ,[CuentaIVAVentas] ,[CuentaIVADevolucionVentas] ,[ComplementoInventarioRemisionado] ,[ComplementoCentroCosto] ,[ComplementoVenta1] ,[TipoArticulo] ,[UnidadesContenidaEmpaque] ,[ArticuloBolsaAgropecuaria] ,[MaximoIVADescontable] ,[ModificarCantidadAlistamientoPorVerificacion]) VALUES ({Codigo} , {Nombre} , {Nombre} , {Grupo} , {Grupo} , {Presentacion}, {Tipo} , {Valorizacion} , {Categoria} , {Iva} , 24081005 , {PrecioVenta}, {Nombre} , 2 , 0 , 0 , 2 , 4 , 4 , 2 , 24080505 , 24081020 , 4 , 4 , 4 , 'G' , 1 , 'N' , {Iva} , 0 )");

            return Ok(insert);
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
