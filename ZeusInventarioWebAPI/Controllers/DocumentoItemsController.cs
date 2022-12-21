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
    public class DocumentoItemsController : ControllerBase
    {
        private readonly Data.InventarioDataContext _context;

        public DocumentoItemsController(Data.InventarioDataContext context)
        {
            _context = context;
        }

        // GET: api/DocumentoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoItem>>> GetDocumentoItems()
        {
          if (_context.DocumentoItems == null)
          {
              return NotFound();
          }
            return await _context.DocumentoItems.ToListAsync();
        }

        
        // Consulta de Productos Facturados en el mes. 
        [HttpGet("ProductosFacturados/{fecha1}/{fecha2}")]
        public ActionResult GetDocumentoItem(DateTime fecha1, DateTime fecha2)
        {
          if (_context.DocumentoItems == null)
          {
              return NotFound();
          }

            DateTime Hora1 = Convert.ToDateTime("00:00:00");
            DateTime Hora2 = Convert.ToDateTime("23:59:00");

            var DocumentoItem = from doc in _context.Set<DocumentoItem>()
                                from fc in _context.Set<FacturaDeCliente>()
                                from i in _context.Set<Item>()
                                from art in _context.Set<Articulo>()
                                where fc.Consecutivo == doc.Documento
                                && i.Codigo == doc.Item
                                && doc.TipoDocumento == 9
                                && i.Articulo == art.IdArticulo
                                && fc.Fecha >= fecha1.AddHours(Hora1.Hour).AddMinutes(Hora1.Minute).AddSeconds(Hora1.Second) //2022-12-01T00:00:00
                                && fc.Fecha <= fecha2.AddHours(Hora2.Hour).AddMinutes(Hora2.Minute).AddSeconds(Hora2.Second) //2022-12-20T23:59:59
                                group doc by new { art.Codigo, art.IdArticulo, art.Nombre, doc.Item, doc.PrecioUnidad} into grupo
                                orderby grupo.Count() descending
                                select new
                                {   
                                    Item = grupo.Key.Item,
                                    CodigoItem =  grupo.Key.Codigo,
                                    Articulo = grupo.Key.IdArticulo,
                                    NombreArticulo = grupo.Key.Nombre,
                                    CantidadFact = grupo.Count(),
                                    TotalxItem = grupo.Sum(d => d.PrecioTotal)
                                };

            if (DocumentoItem == null)
            {
                return NotFound();
            }

            return Ok(DocumentoItem);
        }

        /** Clientes mas facturados en el mes */
        [HttpGet("ClientesFacturadosMes/{fecha1}/{fecha2}")]
        public ActionResult GetDocumento(DateTime fecha1, DateTime fecha2)
        {
            if (_context.DocumentoItems == null)
            {
                return NotFound();
            }

            DateTime Hora1 = Convert.ToDateTime("00:00:00");
            DateTime Hora2 = Convert.ToDateTime("23:59:00");

            var DocumentoItem = from doc in _context.Set<DocumentoItem>()
                                from fc in _context.Set<FacturaDeCliente>()
                                where fc.Consecutivo == doc.Documento
                                && doc.TipoDocumento == 9
                                && fc.Fecha >= fecha1.AddHours(Hora1.Hour).AddMinutes(Hora1.Minute).AddSeconds(Hora1.Second) //2022-12-01T00:00:00
                                && fc.Fecha <= fecha2.AddHours(Hora2.Hour).AddMinutes(Hora2.Minute).AddSeconds(Hora2.Second) //2022-12-20T23:59:59
                                group doc by new { fc.Cliente } into grupo
                                orderby grupo.Count() descending
                                select new
                                {
                                    Cliente = grupo.Key.Cliente,
                                    TotalxItem = grupo.Sum(d => d.PrecioTotal)
                                };

            if (DocumentoItem == null)
            {
                return NotFound();
            }

            return Ok(DocumentoItem);
        }

        /** Vendedores mas facturados en el mes */
        [HttpGet("VendedoresFacturadosMes/{fecha1}/{fecha2}")]
        public ActionResult GetDocumentoxVendedor(DateTime fecha1, DateTime fecha2)
        {
            if (_context.DocumentoItems == null)
            {
                return NotFound();
            }

            DateTime Hora1 = Convert.ToDateTime("00:00:00");
            DateTime Hora2 = Convert.ToDateTime("23:59:00");

            var DocumentoItem = from doc in _context.Set<DocumentoItem>()
                                from fc in _context.Set<FacturaDeCliente>()
                                from ve in _context.Set<Maevende>()
                                where fc.Consecutivo == doc.Documento
                                && ve.Idvende == fc.Vendedor 
                                && doc.TipoDocumento == 9
                                && fc.Fecha >= fecha1.AddHours(Hora1.Hour).AddMinutes(Hora1.Minute).AddSeconds(Hora1.Second) //2022-12-01T00:00:00
                                && fc.Fecha <= fecha2.AddHours(Hora2.Hour).AddMinutes(Hora2.Minute).AddSeconds(Hora2.Second) //2022-12-20T23:59:59
                                group doc by new { fc.Vendedor, ve.Nombvende } into grupo
                                orderby grupo.Count() descending
                                select new
                                {
                                    IdVendedor = grupo.Key.Vendedor,
                                    Venderor = grupo.Key.Nombvende,
                                    TotalxItem = grupo.Sum(d => d.PrecioTotal)
                                };

            if (DocumentoItem == null)
            {
                return NotFound();
            }

            return Ok(DocumentoItem);
        }

    }
}
