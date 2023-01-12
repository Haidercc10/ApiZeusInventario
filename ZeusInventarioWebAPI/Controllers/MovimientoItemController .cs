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
            var ano = DateTime.Today;

            var MovimientoItem = (from mi in _context.Set<MovimientoItem>()
                                  where mi.Fuente == "FV"
                                  && mi.Estado == "Procesado"
                                  && mi.FechaDocumento.Month == ano.Month
                                  && mi.FechaDocumento.Year == ano.Year
                                  select mi.PrecioTotal).Sum();

            var Transaccion1 = (from tr in _context.Set<Transac>()
                                where tr.Idfuente == "DV"
                                && tr.Tipofac == "FA"
                                && tr.Indcpitra == "1"
                                && tr.Fgratra.Month == ano.Month
                                && tr.Fgratra.Year == ano.Year
                                select tr.Valortra).Sum();
            var datos = MovimientoItem - Transaccion1;

            return Ok(datos);
        }


        // GET: api/MovimientoItems/5
        [HttpGet("FacturacionTodosMeses/{mes}/{ano}")]
        public ActionResult FacturacionTodosMeses(int mes, int ano)
        {
            if (_context.MovimientoItems == null)
            {
                return NotFound();
            }

            var MovimientoItem = (from mi in _context.Set<MovimientoItem>()
                                        where mi.Fuente == "FV"
                                        && mi.Estado == "Procesado"
                                        && mi.FechaDocumento.Month == mes
                                        && mi.FechaDocumento.Year == ano
                                        select mi.PrecioTotal).Sum();

            var Transaccion1 = (from tr in _context.Set<Transac>()
                                        where tr.Idfuente == "DV"
                                        && tr.Tipofac == "FA"
                                        && tr.Indcpitra == "1"
                                        && tr.Fgratra.Month == mes
                                        && tr.Fgratra.Year == ano
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

        [HttpGet("getPedidos")]
        public ActionResult getPedidos()
        {
            var con = from mov in _context.Set<MovimientoItem>()
                      from cli in _context.Set<Cliente>()
                      from ped in _context.Set<PedidoDeCliente>()
                      where mov.TipoDocumento == 7
                            && mov.Estado != "Liquidado"
                            && mov.Faltantes < mov.Cantidad
                            && cli.Idcliente == mov.Tercero
                            && ped.Consecutivo == mov.Consecutivo
                      select new
                      {
                          mov.Consecutivo,
                          Fecha_Creacion = mov.FechaDocumento,
                          Id_Cliente = mov.Tercero,
                          Cliente = mov.NombreTercero,
                          cli.Ciudad,
                          Id_Producto = mov.CodigoArticulo,
                          Producto = mov.NombreArticulo,
                          Cant_Pedida = mov.Cantidad,
                          Cant_Pendiente = (mov.Cantidad - mov.Faltantes),
                          Cant_Facturada = mov.Faltantes,
                          mov.Presentacion,
                          mov.PrecioUnidad,
                          Id_Vendedor = mov.Vendedor,
                          Vendedor = mov.NombreVendedor,
                          Orden_Compra_CLiente = ped.OrdenCompraCliente,
                          Costo_Cant_Pendiente = ((mov.Cantidad - mov.Faltantes) * mov.PrecioUnidad),
                          Costo_Cant_Total = (mov.Cantidad * mov.PrecioUnidad),
                          Fecha_Entrega = ped.FechaEntrega,
                          Existencias = (from art in _context.Set<Articulo>()
                                         join ext in _context.Set<Existencia>() on art.IdArticulo equals ext.Articulo
                                         where art.Codigo == mov.CodigoArticulo
                                               && art.DesHabilitado == false
                                               && art.Presentacion == mov.Presentacion
                                         group ext by ext.Articulo into ext
                                         select ext.Sum(x => x.Existencias)).FirstOrDefault(),
                          mov.Estado
                      };
            return Ok(con);
        }

        [HttpGet("getPedidosPorConsecutivo/{consecutivo}")]
        public ActionResult getPedidosPDF(int consecutivo)
        {
            var con = from mov in _context.Set<MovimientoItem>()
                      from cli in _context.Set<Cliente>()
                      from ped in _context.Set<PedidoDeCliente>()
                      where mov.TipoDocumento == 7
                            && cli.Idcliente == mov.Tercero
                            && ped.Consecutivo == mov.Consecutivo
                            && mov.Consecutivo == consecutivo
                      select new
                      {
                          mov.Consecutivo,
                          Fecha_Creacion = mov.FechaDocumento,
                          Id_Cliente = mov.Tercero,
                          Cliente = mov.NombreTercero,
                          cli.Ciudad,
                          Id_Producto = mov.CodigoArticulo,
                          Producto = mov.NombreArticulo,
                          Existencias = (from art in _context.Set<Articulo>()
                                         join ext in _context.Set<Existencia>() on art.IdArticulo equals ext.Articulo
                                         where art.Codigo == mov.CodigoArticulo
                                               && art.DesHabilitado == false
                                               && art.Presentacion == mov.Presentacion
                                         group ext by ext.Articulo into ext
                                         select ext.Sum(x => x.Existencias)).FirstOrDefault(),
                          Cant_Pedida = mov.Cantidad,
                          Cant_Pendiente = (mov.Cantidad - mov.Faltantes),
                          Cant_Facturada = mov.Faltantes,
                          mov.Presentacion,
                          mov.PrecioUnidad,
                          Id_Vendedor = mov.Vendedor,
                          Vendedor = mov.NombreVendedor,
                          Orden_Compra_CLiente = ped.OrdenCompraCliente,
                          Costo_Cant_Pendiente = ((mov.Cantidad - mov.Faltantes) * mov.PrecioUnidad),
                          Costo_Cant_Total = (mov.Cantidad * mov.PrecioUnidad),
                          Fecha_Entrega = ped.FechaEntrega,
                          mov.Estado,
                          Empresa = "Plasticaribe SAS",
                          NIT = 800188732,
                          Direccion = "Calle 42 #52-105",
                          Ciudad_Empresa = "Barranquilla"                         
                      };
            return Ok(con);
        }

        //GET: Consulta para obtener el listado de clientes
        [HttpGet("getPedidosCliente")]
        public ActionResult GetPedidosClientes()
        {
            var con = from mov in _context.Set<MovimientoItem>()
                      from cli in _context.Set<Cliente>()
                      from ped in _context.Set<PedidoDeCliente>()
                      where mov.TipoDocumento == 7
                            && mov.Estado != "Liquidado"
                            && mov.Faltantes < mov.Cantidad
                            && cli.Idcliente == mov.Tercero
                            && ped.Consecutivo == mov.Consecutivo
                      group mov by new
                      {
                          Id_Cliente = mov.Tercero,
                          Cliente = mov.NombreTercero
                      } into mov
                      select new
                      {
                          mov.Key.Id_Cliente,
                          mov.Key.Cliente,
                          Costo = (mov.Sum(x => x.Cantidad * x.PrecioUnidad)),
                          Cantidad = mov.Count()
                      };
            return Ok(con);
        }

        //GET: Consulta para obtener el listado de productos
        [HttpGet("getPedidosProductos")]
        public ActionResult GetPedidosProductos()
        {
            var con = from mov in _context.Set<MovimientoItem>()
                      from cli in _context.Set<Cliente>()
                      from ped in _context.Set<PedidoDeCliente>()
                      where mov.TipoDocumento == 7
                            && mov.Estado != "Liquidado"
                            && mov.Faltantes < mov.Cantidad
                            && cli.Idcliente == mov.Tercero
                            && ped.Consecutivo == mov.Consecutivo
                      group mov by new
                      {
                          Id_Producto = mov.CodigoArticulo,
                          Producto = mov.NombreArticulo,
                      } into mov
                      select new
                      {
                          mov.Key.Id_Producto,
                          mov.Key.Producto,
                          Costo = (mov.Sum(x => x.Cantidad * x.PrecioUnidad)),
                          Cantidad = mov.Count()
                      };
            return Ok(con);
        }

        //GET: Consulta para obtener el listado de productos
        [HttpGet("getPedidosVendedores")]
        public ActionResult GetPedidosVendedores()
        {
            var con = from mov in _context.Set<MovimientoItem>()
                      from cli in _context.Set<Cliente>()
                      from ped in _context.Set<PedidoDeCliente>()
                      where mov.TipoDocumento == 7
                            && mov.Estado != "Liquidado"
                            && mov.Faltantes < mov.Cantidad
                            && cli.Idcliente == mov.Tercero
                            && ped.Consecutivo == mov.Consecutivo
                      group mov by new
                      {
                          Id_Vendedor = mov.Vendedor,
                          Vendedor = mov.NombreVendedor,
                      } into mov
                      select new
                      {
                          mov.Key.Id_Vendedor,
                          mov.Key.Vendedor,
                          Costo = (mov.Sum(x => x.Cantidad * x.PrecioUnidad)),
                          Cantidad = mov.Count()
                      };
            return Ok(con);
        }

        //GET: Consulta para obtener el listado de productos
        [HttpGet("getPedidosEstados")]
        public ActionResult GetPedidosEstados()
        {
            var con = from mov in _context.Set<MovimientoItem>()
                      from cli in _context.Set<Cliente>()
                      from ped in _context.Set<PedidoDeCliente>()
                      where mov.TipoDocumento == 7
                            && mov.Estado != "Liquidado"
                            && mov.Faltantes < mov.Cantidad
                            && cli.Idcliente == mov.Tercero
                            && ped.Consecutivo == mov.Consecutivo
                      group mov by new
                      {
                          mov.Estado,
                      } into mov
                      select new
                      {
                          mov.Key.Estado,
                          Costo = (mov.Sum(x => x.Cantidad * x.PrecioUnidad)),
                          Cantidad = mov.Count()
                      };
            return Ok(con);
        }

        //GET: Consulta para obtener el listado de productos
        [HttpGet("getPedidosStock")]
        public ActionResult GetPedidosStock()
        {
            var con = from mov in _context.Set<MovimientoItem>()
                      from cli in _context.Set<Cliente>()
                      from ped in _context.Set<PedidoDeCliente>()
                      where mov.TipoDocumento == 7
                            && mov.Estado != "Liquidado"
                            && mov.Faltantes < mov.Cantidad
                            && cli.Idcliente == mov.Tercero
                            && ped.Consecutivo == mov.Consecutivo
                            && (from art in _context.Set<Articulo>()
                                join ext in _context.Set<Existencia>() on art.IdArticulo equals ext.Articulo
                                where art.Codigo == mov.CodigoArticulo
                                    && art.DesHabilitado == false
                                    && art.Presentacion == mov.Presentacion
                                group ext by ext.Articulo into ext
                                select ext.Sum(x => x.Existencias)).FirstOrDefault() >= (mov.Cantidad - mov.Faltantes)
                      select new
                      {
                          mov.Consecutivo,
                          Fecha_Creacion = mov.FechaDocumento,
                          Id_Cliente = mov.Tercero,
                          Cliente = mov.NombreTercero,
                          cli.Ciudad,
                          Id_Producto = mov.CodigoArticulo,
                          Producto = mov.NombreArticulo,
                          Existencias = (from art in _context.Set<Articulo>()
                                         join ext in _context.Set<Existencia>() on art.IdArticulo equals ext.Articulo
                                         where art.Codigo == mov.CodigoArticulo
                                               && art.DesHabilitado == false
                                               && art.Presentacion == mov.Presentacion
                                         group ext by ext.Articulo into ext
                                         select ext.Sum(x => x.Existencias)).FirstOrDefault(),
                          Cant_Pedida = mov.Cantidad,
                          Cant_Pendiente = (mov.Cantidad - mov.Faltantes),
                          Cant_Facturada = mov.Faltantes,
                          mov.Presentacion,
                          mov.PrecioUnidad,
                          Id_Vendedor = mov.Vendedor,
                          Vendedor = mov.NombreVendedor,
                          Orden_Compra_CLiente = ped.OrdenCompraCliente,
                          Costo_Cant_Pendiente = ((mov.Cantidad - mov.Faltantes) * mov.PrecioUnidad),
                          Costo_Cant_Total = (mov.Cantidad * mov.PrecioUnidad),
                          Fecha_Entrega = ped.FechaEntrega,
                          mov.Estado,
                      };
            return Ok(con);
        }
    }
}
