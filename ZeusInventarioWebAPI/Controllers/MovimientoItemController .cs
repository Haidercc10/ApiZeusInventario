using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NuGet.Protocol;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text.Json.Nodes;
using ZeusInventarioWebAPI.Data;
using ZeusInventarioWebAPI.Models;

namespace ZeusInventarioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
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
            var mes = Convert.ToString(ano.Month).Length == 1 ? "0" + Convert.ToString(ano.Month) : Convert.ToString(ano.Month);

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
                                && tr.Fechatra.Substring(5, 2) == mes
                                && tr.Fechatra.Substring(0, 4) == Convert.ToString(ano.Year)
                                select tr.Valortra).Sum();
            var datos = MovimientoItem - Transaccion1;

            return Ok(datos);
        }

        // GET: api/MovimientoItems/5
        [HttpGet("FacturacionTodosMeses/{mes}/{ano}")]
        public ActionResult FacturacionTodosMeses(string mes, int ano)
        {
            var MovimientoItem = (from mi in _context.Set<MovimientoItem>()
                                  where mi.Fuente == "FV"
                                  && mi.Estado == "Procesado"
                                  && mi.FechaDocumento.Month == Convert.ToInt32(mes)
                                  && mi.FechaDocumento.Year == ano
                                  select mi.PrecioTotal).Sum();

            var Transaccion1 = (from tr in _context.Set<Transac>()
                                where tr.Idfuente == "DV"
                                && tr.Tipofac == "FA"
                                && tr.Indcpitra == "1"
                                && tr.Fechatra.Substring(5, 2) == Convert.ToString(mes)
                                && tr.Fechatra.Substring(0, 4) == Convert.ToString(ano)
                                select tr.Valortra).Sum();

            var datos = MovimientoItem - Transaccion1;

            return Ok(datos);
        }

        // Consulta que devovlerá un array con cada uno de los meses y el valor que se facturó mes mes en el año que le sea pasado
        [HttpGet("getFacturacion_Mes_Mes/{anio}")]
        public ActionResult FacturacionTodosMeses(int anio)
        {
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            var datos = new List<object>();
            for (int i = 0; i < 12; i++)
            {
                string mes = (i + 1).ToString().Length > 1 ? $"{i + 1}" : $"0{i + 1}";
                var MovimientoItem = (from mi in _context.Set<MovimientoItem>()
                                      where mi.Fuente == "FV"
                                      && mi.Estado == "Procesado"
                                      && mi.FechaDocumento.Month == Convert.ToInt32(mes)
                                      && mi.FechaDocumento.Year == anio
                                      select mi.PrecioTotal).Sum();

                var Transaccion1 = (from tr in _context.Set<Transac>()
                                    where tr.Idfuente == "DV"
                                    && tr.Tipofac == "FA"
                                    && tr.Indcpitra == "1"
                                    && tr.Fechatra.Substring(5, 2) == Convert.ToString(mes)
                                    && tr.Fechatra.Substring(0, 4) == Convert.ToString(anio)
                                    select tr.Valortra).Sum();

                datos.Add($"'Mes': '{mes}', 'Valor': '{Convert.ToDecimal(MovimientoItem - Transaccion1)}'");
                if (i == 11) return Ok(datos);
            }
            return Ok(datos);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
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

        [HttpGet("getPedidosAgrupados")]
        public ActionResult getPedidosAgrupados()
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
                          mov.Consecutivo,
                          mov.FechaDocumento,
                          mov.Tercero,
                          mov.NombreTercero,
                          ped.FechaEntrega,
                          mov.Vendedor,
                          mov.NombreVendedor,
                          ped.OrdenCompraCliente,
                          mov.Estado
                      } into mov
                      select new
                      {
                          mov.Key.Consecutivo,
                          Fecha_Creacion = mov.Key.FechaDocumento,
                          Id_Cliente = mov.Key.Tercero,
                          Cliente = mov.Key.NombreTercero,
                          Id_Vendedor = mov.Key.Vendedor,
                          Vendedor = mov.Key.NombreVendedor,
                          Orden_Compra_CLiente = mov.Key.OrdenCompraCliente,
                          Fecha_Entrega = mov.Key.FechaEntrega,
                          mov.Key.Estado
                      };
            return Ok(con);
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
                      //from art in _context.Set<Articulo>()
                      //from ext in _context.Set<Existencia>()
                      //join ext in _context.Set<Existencia>() on art.IdArticulo equals ext.Articulo
                      where mov.TipoDocumento == 7
                            && cli.Idcliente == mov.Tercero
                            //&& ext.Articulo == art.IdArticulo
                            //&& art.Codigo == mov.CodigoArticulo
                            //&& art.DesHabilitado == false
                            //&& art.Presentacion == mov.Presentacion
                            && ped.Consecutivo == mov.Consecutivo
                            && mov.Consecutivo == consecutivo
                      select new
                      {
                          mov.Consecutivo,
                          Fecha_Creacion = mov.FechaDocumento,
                          Id_Cliente = mov.Tercero,
                          Cliente = mov.NombreTercero,
                          cli.Ciudad,
                          Direccion_Cliente = cli.Direccion,
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
                          Ciudad_Empresa = "Barranquilla",
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

        //GET: Consullta para obtener un consolidad de los productos comprados por cliente cada mes año a año, esta consultará entre un ragon de años y/o un vendedor y/o un cliente y/o un producto
        [HttpGet("getConsolidadoClientesArticulo/{ano1}/{ano2}")]
        public ActionResult GetConsolidadClientesArticulo(int ano1, int ano2, string? vendedor = "", string? nombreVendedor = "", string? producto = "", string? nombreProducto = "", string? cliente = "", string? nombreCliente = "")
        {
#pragma warning disable CS8604 // Posible argumento de referencia nulo
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var con = from mov in _context.Set<MovimientoItem>()
                      where mov.Vendedor.Contains(vendedor)
                            && mov.NombreVendedor.Contains(nombreVendedor)
                            && mov.CodigoArticulo.Contains(producto)
                            && mov.NombreArticulo.Contains(nombreProducto)
                            && mov.Tercero.Contains(cliente)
                            && mov.NombreTercero.Contains(nombreCliente)
                            && mov.TipoDocumento == 9
                            && mov.FechaDocumento.Year >= ano1
                            && mov.FechaDocumento.Year <= ano2
                            && mov.Fuente == "FV"
                            && mov.Estado == "Procesado"
                      group mov by new
                      {
                          Mes = mov.FechaDocumento.Month,
                          Ano = mov.FechaDocumento.Year,
                          Id_Cliente = mov.Tercero,
                          Cliente = mov.NombreTercero,
                          Id_Producto = mov.CodigoArticulo,
                          Producto = mov.NombreArticulo,
                          Presentacion = mov.Presentacion,
                          Precio = mov.PrecioUnidad,
                          Id_Vendedor = mov.Vendedor,
                          Vendedor = mov.NombreVendedor,
                      } into mov
                      orderby mov.Key.Ano ascending, mov.Key.Mes ascending
                      select new
                      {
                          mov.Key.Mes,
                          mov.Key.Ano,
                          mov.Key.Id_Cliente,
                          mov.Key.Cliente,
                          mov.Key.Id_Producto,
                          mov.Key.Producto,
                          Cantidad = Convert.ToDecimal(mov.Sum(x => x.Cantidad)),
                          Devolucion = Convert.ToDecimal(0),
                          mov.Key.Presentacion,
                          mov.Key.Precio,
                          SubTotal = Convert.ToDecimal(mov.Sum(x => x.PrecioTotal)),
                          mov.Key.Id_Vendedor,
                          mov.Key.Vendedor,
                      };

            var devolucion = from mov in _context.Set<MovimientoItem>()
                             from tr in _context.Set<Transac>()
                             from dev in _context.Set<DevolucionVenta>()
                             where tr.Idvende.Contains(vendedor)
                                   && mov.CodigoDocumento == dev.Consecutivo
                                   && mov.Vendedor.Contains(vendedor)
                                   && mov.NombreVendedor.Contains(nombreVendedor)
                                   && mov.CodigoArticulo.Contains(producto)
                                   && mov.NombreArticulo.Contains(nombreProducto)
                                   && mov.Tercero.Contains(cliente)
                                   && mov.NombreTercero.Contains(nombreCliente)
                                   && tr.Numdoctra == dev.Documento
                                   && mov.TipoDocumento == 26
                                   && tr.Idfuente == "DV"
                                   && tr.Tipofac == "FA"
                                   && tr.Indcpitra == "1"
                                   && dev.Fuente == "DV"
                                   && mov.FechaDocumento.Year >= ano1
                                   && mov.FechaDocumento.Year <= ano2
                             group new { mov, tr } by new
                             {
                                 Mes = mov.FechaDocumento.Month,
                                 Ano = mov.FechaDocumento.Year,
                                 Id_Cliente = mov.Tercero,
                                 Cliente = mov.NombreTercero,
                                 Id_Producto = mov.CodigoArticulo,
                                 Producto = mov.NombreArticulo,
                                 Presentacion = mov.Presentacion,
                                 Precio = mov.PrecioUnidad,
                                 Id_Vendedor = mov.Vendedor,
                                 Vendedor = mov.NombreVendedor,
                             } into mov
                             orderby mov.Key.Ano ascending, mov.Key.Mes ascending
                             select new
                             {
                                 mov.Key.Mes,
                                 mov.Key.Ano,
                                 mov.Key.Id_Cliente,
                                 mov.Key.Cliente,
                                 mov.Key.Id_Producto,
                                 mov.Key.Producto,
                                 Cantidad = Convert.ToDecimal(0),
                                 Devolucion = Convert.ToDecimal(mov.Sum(x => x.mov.Cantidad) * -1),
                                 mov.Key.Presentacion,
                                 mov.Key.Precio,
                                 SubTotal = Convert.ToDecimal(mov.Sum(x => x.tr.Valortra) * -1),
                                 mov.Key.Id_Vendedor,
                                 mov.Key.Vendedor
                             };
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning restore CS8604 // Posible argumento de referencia nulo
            return Ok(con.Concat(devolucion));
        }

        [HttpGet("getArticulosxCliente/{idcliente}")]
        public ActionResult GetArticulosxCliente(string idcliente)
        {
            var items = (from mov in _context.Set<MovimientoItem>()
                         where mov.TipoDocumento == 9
                         && mov.Tercero == idcliente
                         select new
                         {
                             codigo = mov.CodigoArticulo,
                             nombre = mov.NombreArticulo
                         }).Distinct();
            return Ok(items);
        }

        // Funcion que conultará un pedido por sus consecutivo
        [HttpGet("getInfoPedido_Consecutivo/{id}")]
        public ActionResult GetInfoPedido_Consecutivo(int id)
        {
            var con = from mov in _context.Set<MovimientoItem>()
                      from cli in _context.Set<Cliente>()
                      from ped in _context.Set<PedidoDeCliente>()
                      where mov.TipoDocumento == 7
                            && mov.Estado != "Liquidado"
                            && mov.Faltantes < mov.Cantidad
                            && cli.Idcliente == mov.Tercero
                            && ped.Consecutivo == mov.Consecutivo
                            && mov.Consecutivo == id
                      select new
                      {
                          mov.Consecutivo,
                          Fecha_Creacion = mov.FechaDocumento,
                          Id_Cliente = mov.Tercero,
                          Cliente = mov.NombreTercero,
                          cli.Ciudad,
                          Direccion_Cliente = cli.Direccion,
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
                          Ciudad_Empresa = "Barranquilla",
                      };
            return Ok(con);
        }

        // Consulta que devolverá el costo total de las devoluciones en un lapso de años
        [HttpGet("getDevoluciones/{anio1}/{anio2}")]
        public ActionResult GetDevoluciones(int anio1, int anio2)
        {
            var Transaccion1 = (from tr in _context.Set<Transac>()
                                where tr.Idfuente == "DV"
                                && tr.Tipofac == "FA"
                                && tr.Indcpitra == "1"
                                && Convert.ToInt32(tr.Fechatra.Substring(0, 4)) >= anio1
                                && Convert.ToInt32(tr.Fechatra.Substring(0, 4)) <= anio2
                                select tr.Valortra).Sum();
            return Ok(Transaccion1);
        }

        //Consulta que devolver la costo facturado por mes de cada vendedor
        [HttpGet("getCostoFacturado_Vendedor/{vendedor}/{mes}/{anio}")]
        public ActionResult GetCostoFacturado_Vendedor(string vendedor, string mes, int anio)
        {
            var MovimientoItem = (from mi in _context.Set<MovimientoItem>()
                                  where mi.Fuente == "FV"
                                  && mi.Estado == "Procesado"
                                  && mi.FechaDocumento.Month == Convert.ToInt32(mes)
                                  && mi.FechaDocumento.Year == anio
                                  && mi.Vendedor == vendedor
                                  select mi.PrecioTotal).Sum();

            var Transaccion1 = (from tr in _context.Set<Transac>()
                                where tr.Idfuente == "DV"
                                && tr.Tipofac == "FA"
                                && tr.Indcpitra == "1"
                                && tr.Fechatra.Substring(5, 2) == Convert.ToString(mes)
                                && tr.Fechatra.Substring(0, 4) == Convert.ToString(anio)
                                && tr.Idvende == vendedor
                                select tr.Valortra).Sum();

            var datos = MovimientoItem - Transaccion1;
            return Ok(datos);
        }

        //Consulta que devolverá la informacion de los clientes que mas se han facturado en el mes y restará las devoluciones que han tenido estos mismos
        [HttpGet("getClienteFacturadosMes")]
        public ActionResult GetClientesFacturadosMes()
        {
#pragma warning disable CA1827 // Do not use Count() or LongCount() when Any() can be used
            DateTime fecha = DateTime.Today;
            var con = from fv in _context.Set<FacturaDeCliente>()
                      from cli in _context.Set<Cliente>()
                      where fv.Fuente == "FV"
                            && fv.Estado == "Procesado"
                            && fv.Fecha.Year == fecha.Year
                            && fv.Fecha.Month == fecha.Month
                            && cli.Idtercero == fv.Cliente
                      group fv by new
                      {
                          Anio = fv.Fecha.Year,
                          Mes = fv.Fecha.Month,
                          Id_Cliente = fv.Cliente,
                          Cliente = cli.Razoncial
                      } into fv
                      orderby fv.Count() descending
                      select new
                      {
                          fv.Key.Anio,
                          fv.Key.Mes,
                          fv.Key.Id_Cliente,
                          fv.Key.Cliente,
                          Cantidad = fv.Count(),
                          Costo = (from mov in _context.Set<MovimientoItem>()
                                   where mov.TipoDocumento == 9
                                         && mov.Fuente == "FV"
                                         && mov.Estado == "Procesado"
                                         && mov.FechaDocumento.Year == fecha.Year
                                         && mov.FechaDocumento.Month == fecha.Month
                                         && mov.Tercero == fv.Key.Id_Cliente
                                   select mov.PrecioTotal).Sum() - (from tr in _context.Set<Transac>()
                                                                    where tr.Idfuente == "DV"
                                                                          && tr.Tipofac == "FA"
                                                                          && tr.Indcpitra == "1"
                                                                          && tr.Fechatra.Substring(5, 2) == Convert.ToString(fecha.Month)
                                                                          && tr.Fechatra.Substring(0, 4) == Convert.ToString(fecha.Year)
                                                                          && tr.Nittra == fv.Key.Id_Cliente
                                                                    select tr.Valortra).Sum()
                      };
            if (con.Count() > 0) return Ok(con);
            else return BadRequest("No se encontraron clientes con facturas en el mes");
#pragma warning restore CA1827 // Do not use Count() or LongCount() when Any() can be used
        }

        //Consulta que devolverá la informacion de los productos que mas se han facturado en el mes 
        [HttpGet("getProductosFaturadosMes")]
        public ActionResult GetClientesFacturadoMes()
        {
            DateTime fecha = DateTime.Today;
            var con = from mov in _context.Set<MovimientoItem>()
                      where mov.TipoDocumento == 9
                            && mov.Fuente == "FV"
                            && mov.Estado == "Procesado"
                            && mov.FechaDocumento.Year == fecha.Year
                            && mov.FechaDocumento.Month == fecha.Month
                      group mov by new
                      {
                          Anio = mov.FechaDocumento.Year,
                          Mes = mov.FechaDocumento.Month,
                          Id_Producto = mov.CodigoArticulo,
                          Producto = mov.NombreArticulo
                      } into mov
                      orderby mov.Count() descending
                      select new
                      {
                          mov.Key.Anio,
                          mov.Key.Mes,
                          mov.Key.Id_Producto,
                          mov.Key.Producto,
                          Cantidad = mov.Count(),
                          Costo = mov.Sum(x => x.PrecioTotal)
                      };
            if (con.Count() > 0) return Ok(con);
            else return BadRequest("No se encontraron clientes con facturas en el mes");
        }

        //Consulta que devolverá la informacion de los vendedores que mas han hecho facturas este mes
        [HttpGet("getVendedoresFacturasMes")]
        public ActionResult GetVendedoresFacturasMes()
        {
            DateTime fecha = DateTime.Today;
            var con = from fv in _context.Set<FacturaDeCliente>()
                      from ven in _context.Set<Maevende>()
                      where fv.Fuente == "FV"
                            && fv.Estado == "Procesado"
                            && fv.Fecha.Year == fecha.Year
                            && fv.Fecha.Month == fecha.Month
                            && fv.Vendedor == ven.Idvende
                      group fv by new
                      {
                          Anio = fv.Fecha.Year,
                          Mes = fv.Fecha.Month,
                          Id_Vendedor = fv.Vendedor,
                          Vendedor = ven.Nombvende
                      } into fv
                      orderby fv.Count() descending
                      select new
                      {
                          fv.Key.Anio,
                          fv.Key.Mes,
                          fv.Key.Id_Vendedor,
                          fv.Key.Vendedor,
                          Cantidad = fv.Count(),
                          Costo = (from mov in _context.Set<MovimientoItem>()
                                   where mov.TipoDocumento == 9
                                         && mov.Fuente == "FV"
                                         && mov.Estado == "Procesado"
                                         && mov.FechaDocumento.Year == fecha.Year
                                         && mov.FechaDocumento.Month == fecha.Month
                                         && mov.Vendedor == fv.Key.Id_Vendedor
                                   select mov.PrecioTotal).Sum() - (from tr in _context.Set<Transac>()
                                                                    where tr.Idfuente == "DV"
                                                                          && tr.Tipofac == "FA"
                                                                          && tr.Indcpitra == "1"
                                                                          && tr.Fechatra.Substring(5, 2) == Convert.ToString(fecha.Month)
                                                                          && tr.Fechatra.Substring(0, 4) == Convert.ToString(fecha.Year)
                                                                          && tr.Idvende == fv.Key.Id_Vendedor
                                                                    select tr.Valortra).Sum()
                      };
            if (con.Count() > 0) return Ok(con);
            else return BadRequest("No se encontraron vendedores con facturas en el mes");
        }

        /** Consulta que devolverá las compras realizadas por plasticaribe en cada mes */
        [HttpGet("getComprasMes/{anio}/{mes}")]
        public ActionResult GetComprasMes(string anio, string mes)
        {
            var con = (from mov in _context.Set<MovimientoItem>()
                       from prov in _context.Set<Proveedore>()
                       from ent in _context.Set<Entradum>()
                       where mov.CodigoDocumento == ent.Consecutivo
                             && ent.Proveedor == prov.Idprove
                             && ent.Proveedor != "900362200"
                             && ent.Proveedor != "900458314"
                             && mov.TipoDocumento == 2
                             && Convert.ToString(mov.FechaDocumento.Year) == anio
                             && Convert.ToString(mov.FechaDocumento.Month) == mes
                       select mov.CostoTotal).Sum();

            return Ok(con);
        }

        /** Consulta que devolverá las compras realizadas por plasticaribe en cada mes */
        [HttpGet("getComprasMesInverGoal_InverSuez/{anio}/{mes}/{proveedor}")]
        public ActionResult GetComprasMesInverGoal(string anio, string mes, string proveedor)
        {
            var con = (from mov in _context.Set<MovimientoItem>()
                       from prov in _context.Set<Proveedore>()
                       from ent in _context.Set<Entradum>()
                       where mov.CodigoDocumento == ent.Consecutivo
                             && ent.Proveedor == prov.Idprove
                             && ent.Proveedor == proveedor
                             && mov.TipoDocumento == 2
                             && Convert.ToString(mov.FechaDocumento.Year) == anio
                             && Convert.ToString(mov.FechaDocumento.Month) == mes
                       select mov.CostoTotal).Sum();

            return Ok(con);
        }

        //Consulta que devolverá las compras de plasticaribe mes a mes en el año que le sea pasado
        [HttpGet("getComprasMes_Mes_Plasticaribe/{anio}")]
        public ActionResult GetComprasMes_Mes_Plasticaribe(string anio)
        {
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            var datos = new List<object>();
            for (int i = 0; i < 12; i++)
            {
                string mes = (i + 1).ToString().Length > 1 ? $"{i + 1}" : $"0{i + 1}";
                var con = (from mov in _context.Set<MovimientoItem>()
                           from prov in _context.Set<Proveedore>()
                           from ent in _context.Set<Entradum>()
                           where mov.CodigoDocumento == ent.Consecutivo
                                 && ent.Proveedor == prov.Idprove
                                 && ent.Proveedor != "900362200"
                                 && ent.Proveedor != "900458314"
                                 && mov.TipoDocumento == 2
                                 && Convert.ToString(mov.FechaDocumento.Year) == anio
                                 && Convert.ToString(mov.FechaDocumento.Month) == $"{i + 1}"
                           select mov.CostoTotal).Sum();

                datos.Add($"'Mes': '{mes}', 'Valor': '{Convert.ToDecimal(con)}'");
                if (i == 11) return Ok(datos);
            }
            return Ok(datos);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
        }

        //Consulta que devolverá las compras de invergoal e inversuez mes a mes en el año que le sea pasado
        [HttpGet("getComprasMes_Mes_InverGoal_InverSuez/{anio}/{proveedor}")]
        public ActionResult GetComprasMes_Mes_InverGoal_InverSuez(string anio, string proveedor)
        {
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            var datos = new List<object>();
            for (int i = 0; i < 12; i++)
            {
                string mes = (i + 1).ToString().Length > 1 ? $"{i + 1}" : $"0{i + 1}";
                var con = (from mov in _context.Set<MovimientoItem>()
                           from prov in _context.Set<Proveedore>()
                           from ent in _context.Set<Entradum>()
                           where mov.CodigoDocumento == ent.Consecutivo
                                 && ent.Proveedor == prov.Idprove
                                 && ent.Proveedor == proveedor
                                 && mov.TipoDocumento == 2
                                 && Convert.ToString(mov.FechaDocumento.Year) == anio
                                 && Convert.ToString(mov.FechaDocumento.Month) == $"{i + 1}"
                           select mov.CostoTotal).Sum();

                datos.Add($"'Mes': '{mes}', 'Valor': '{Convert.ToDecimal(con)}'");
                if (i == 11) return Ok(datos);
            }
            return Ok(datos);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
        }

        //Consulta que devolverá las compras de invergoal e inversuez mes a mes en el año que le sea pasado
        [HttpGet("getComprasDetalladas/{proveedor}/{factura}")]
        public ActionResult GetComprasDetalladas(string proveedor, string factura)
        {
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            var con = from mov in _context.Set<MovimientoItem>()
                      from prov in _context.Set<Proveedore>()
                      from ent in _context.Set<Entradum>()
                      where mov.CodigoDocumento == ent.Consecutivo
                            && ent.Proveedor == prov.Idprove
                            && ent.Proveedor == proveedor
                            && ent.FacturaProveedor == factura
                            && mov.TipoDocumento == 2
                      select new
                      {
                          Factura = ent.FacturaProveedor,
                          FechaDoc = mov.FechaDocumento,
                          FechaFactura = ent.FechaFactura,
                          IdProveedor = ent.Proveedor,
                          Proveedor = prov.Razoncial,
                          CodigoMatPrima = mov.CodigoArticulo,
                          MatPrima = mov.NombreArticulo,
                          Unidad = mov.Presentacion,
                          Grupo = mov.NombreGrupo,
                          Cantidad = mov.Cantidad,
                          ValorNeto = mov.CostoTotal,
                          IvaCompras = mov.TotalIvacompras,
                          ValorMasIva = mov.CostoTotal + mov.TotalIvacompras,
                          FechaVence = ent.Vencimiento,
                      };

            if (con == null) return BadRequest("No se encontró la factura consultada para este proveedor");
            else return Ok(con);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
        }

        //Consulta que devolverá las facturas de exportaciones falsas que se le mostrarán a Ecopetrol
        [HttpGet("getFacturasEcopetrol/{factura}/{trm}/{valorFinal}/{fecha}")]
        public ActionResult GetFacturasEcopetrol(string factura, double trm, decimal valorFinal, DateTime fecha)
        {
            var Codigofactura = (from fac in _context.Set<FacturaDeCliente>()
                                 where fac.Fecha >= fecha.AddDays(2) &&
                                       fac.Fecha <= fecha.AddDays(5)
                                 orderby fecha descending
                                 select fac.Documento).FirstOrDefault();

            var fechaDocumento = (from fac in _context.Set<FacturaDeCliente>()
                                  where fac.Documento == Codigofactura
                                  orderby fecha descending
                                  select fac.Fecha).FirstOrDefault();

            var consecutivoBu = (from fac in _context.Set<FacturaDeCliente>()
                                 join mov in _context.Set<MovimientoItem>() on fac.Consecutivo equals mov.CodigoDocumento
                                 where fac.Documento == Codigofactura
                                 orderby fecha descending
                                 select mov.ConsecutivoBu).FirstOrDefault();

#pragma warning disable CS8604 // Posible argumento de referencia nulo
            var con = from mov in _context.Set<MovimientoItem>()
                      from ent in _context.Set<Entradum>()
                      from prv in _context.Set<Proveedore>()
                      where ent.Consecutivo == mov.CodigoDocumento &&
                      ent.Proveedor == prv.Idprove &&
                      mov.TipoDocumento == 2 &&
                      ent.FacturaProveedor == factura
                      select new
                      {
                          NroFv = Codigofactura,
                          NroInterno = Codigofactura,
                          Bu = mov.Bu,
                          ConsecBu = consecutivoBu,
                          Fecha = fechaDocumento,
                          Cliente = "IMPORTADORA IDEA CA",
                          Direccion = "SAN CRISTOBAL, CALLE 12 CRA 15 ESQUINA 11 77",
                          NitCc_Cliente = "444444025",
                          Ciudad = "SAN CRISTOBAL",
                          Telefono = "584247037418",
                          Zona = "99",
                          Vendedor = "VENTA DIRECTA",
                          Moneda = "USD",
                          Medio_Pago = "Acuerdo mutuo",
                          Forma_Pago = "Anticipado",
                          Estado_Factura = "Procesado",
                          Relacionado = "",
                          Codigo_Articulo = 101,
                          Nombre_Articulo = "POLIFEN 641 NEAR PRIME Bolsa 1 25",
                          Presentacion = "KLS",
                          Bodega = "003",
                          Lote = 0,
                          Cantidad = mov.Cantidad,
                          Precio = mov.ValorUnidad,
                          Descuento = 0.00,
                          Iva = 0.00,
                          INC = 0.00,
                          TotalBruto = valorFinal,
                          Observacion = "",
                          Total_Bruto = valorFinal,
                          Total_Descuento = 0.00,
                          Total_Neta = valorFinal,
                          Total_Iva = 0.00,
                          Total_INC = 0.00,
                          Retefuente = 0.00,
                          ReteIva = 0.00,
                          ReteIca = 0.00,
                          OtrosConceptos = 0.00,
                          Anticipo = 0.00,
                          Total_FactElectronica = valorFinal,
                          Usuario = "SISTEMAS"
                      };

            if (con == null) return BadRequest("No se encontraron facturas en las fechas consultadas!");
            else return Ok(con);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
        }

        //Consulta que retornará las ventas detalladas por vendedor en las fechas consultadas
        [HttpGet("getFacturacionDetallada/{fecha1}/{fecha2}")]
        public ActionResult GetFacturacionDetallada(DateTime fecha1, DateTime fecha2, string? cliente = "", string? vendedor = "", string? item = "")
        {
            var facturacion = from f in _context.Set<FacturaDeCliente>()
                              from m in _context.Set<MovimientoItem>()
                              from c in _context.Set<Cliente>()
                              from v in _context.Set<Maevende>()
                              where f.Consecutivo == m.CodigoDocumento &&
                              f.Cliente == c.Idcliente &&
                              m.TipoDocumento == 9 &&
                              f.Vendedor == v.Idvende &&
                              f.Fecha >= fecha1 &&
                              f.Fecha <= fecha2 &&
                              f.Cliente.Contains(cliente) &&
                              f.Vendedor.Contains(vendedor) &&
                              m.CodigoArticulo.Contains(item)
                              select new
                              {
                                  IdVendedor = v.Idvende,
                                  Vendedor = v.Nombvende,
                                  Cliente = c.Razoncial,
                                  Factura = f.Documento,
                                  Fecha = f.Fecha.ToString("yyyy/MM/dd"),
                                  Factura2 = f.Documento.Replace("0000", ""),
                                  Item = m.CodigoArticulo,
                                  Referencia = m.NombreArticulo,
                                  Presentacion = m.Presentacion,
                                  Cantidad = m.Cantidad,
                                  Precio = m.PrecioUnidad,
                                  ValorTotal = (m.Cantidad * m.PrecioUnidad)
                              };

            if (facturacion == null) return Ok("No se encontraron resultados de búsqueda");
            else return Ok(facturacion);
        }

        //Consulta que retornará las devoluciones detalladas en las fechas consultadas
        [HttpGet("getDevolucionesDetalladas/{fecha1}/{fecha2}/{indicadorCPI}")]
        public ActionResult GetDevolucionesVentas(DateTime fecha1, DateTime fecha2, char indicadorCPI, string? cliente = "", string? vendedor = "")
        {
            if (cliente != "" && vendedor != "")
            {
                 return Ok(_context.Set<Transac>().FromSql(
                     $"SELECT T.* FROM TRANSAC T WHERE T.IDFUENTE = 'DV' AND T.TIPOFAC = 'FA' AND CAST(CONVERT(char(10), T.FECHATRA, 112) as date) BETWEEN {fecha1} AND {fecha2} AND T.INDCPITRA = {indicadorCPI} AND T.NITTRA = {cliente} AND T.IDVENDE = {vendedor}").ToList());
            }
            else if (cliente != "")
            {
                 return Ok(_context.Set<Transac>().FromSql(
                     $"SELECT T.* FROM TRANSAC T WHERE T.IDFUENTE = 'DV' AND T.TIPOFAC = 'FA' AND CAST(CONVERT(char(10),T.FECHATRA, 112) as date) BETWEEN {fecha1} AND {fecha2} AND T.INDCPITRA = {indicadorCPI} AND T.NITTRA = {cliente}").ToList());
            }
            else if (vendedor != "")
            {
                 return Ok(_context.Set<Transac>().FromSql(
                     $"SELECT T.* FROM TRANSAC T WHERE T.IDFUENTE = 'DV' AND T.TIPOFAC = 'FA' AND CAST(CONVERT(char(10), T.FECHATRA, 112) as date) BETWEEN {fecha1} AND {fecha2} AND T.INDCPITRA = {indicadorCPI}  AND T.IDVENDE = {vendedor}").ToList());
            }
            
            var devolucion = _context.Set<Transac>().FromSql(
                     $"SELECT T.* FROM TRANSAC T WHERE T.IDFUENTE = 'DV' AND T.TIPOFAC = 'FA' AND CAST(CONVERT(char(10), T.FECHATRA, 112) as date) BETWEEN {fecha1} AND {fecha2} AND T.INDCPITRA = {indicadorCPI}").ToList();

            return Ok(devolucion);
        }

        //Consulta que retornará las facturas consolidadas en las fechas consultadas
        [HttpGet("getFacturacionConsolidada/{fecha1}/{fecha2}")]
        public ActionResult getFacturacionConsolidada(DateTime fecha1, DateTime fecha2, string? cliente = "", string? vendedor = "")
        {
            if (cliente != "" && vendedor != "")
            {
                return Ok(_context.Set<Transac>().FromSql(
                    $"SELECT T.* FROM TRANSAC T WHERE T.IDFUENTE = 'FV' AND T.TIPOFAC = 'FA' AND CAST(CONVERT(char(10), T.FECHATRA, 112) as date) BETWEEN {fecha1} AND {fecha2} AND T.INDCPITRA = 2 AND T.NITTRA = {cliente} AND T.IDVENDE = {vendedor}").ToList());
            }
            else if (cliente != "")
            {
                return Ok(_context.Set<Transac>().FromSql(
                    $"SELECT T.* FROM TRANSAC T WHERE T.IDFUENTE = 'FV' AND T.TIPOFAC = 'FA' AND CAST(CONVERT(char(10), T.FECHATRA, 112) as date) BETWEEN {fecha1} AND {fecha2} AND T.INDCPITRA = 2 AND T.NITTRA = {cliente}").ToList());
            }
            else if (vendedor != "")
            {
                return Ok(_context.Set<Transac>().FromSql(
                    $"SELECT T.* FROM TRANSAC T VWHERE T.IDFUENTE = 'FV' AND T.TIPOFAC = 'FA' AND CAST(CONVERT(char(10), T.FECHATRA, 112) as date) BETWEEN {fecha1} AND {fecha2} AND t.INDCPITRA = 2 AND T.IDVENDE = {vendedor}").ToList());
            }

            var devolucion = _context.Set<Transac>().FromSql(
                    $"SELECT T.* FROM TRANSAC T WHERE  T.IDFUENTE = 'FV' AND T.TIPOFAC = 'FA' AND CAST(CONVERT(char(10), T.FECHATRA, 112) as date) BETWEEN {fecha1} AND {fecha2} AND T.INDCPITRA = 2 AND T.NITTRA LIKE '%%' AND T.IDVENDE LIKE '%%' ").ToList();

            return Ok(devolucion);
        }


    }    
}
