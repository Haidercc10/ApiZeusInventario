using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ZeusInventarioWebAPI.Models;

namespace ZeusInventarioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cruce_DocumentosRelacionadosController : ControllerBase
    {
        private readonly Data.InventarioDataContext _context;

        public Cruce_DocumentosRelacionadosController(Data.InventarioDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetCruceDocumento()
        {
            return Ok(from c in _context.Set<CruceDocumentosRelacionado>() select c);
        }

        [HttpGet("getFactura/{pedido}")]
        public async Task<ActionResult> GetFactura(decimal pedido)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var consecutivoFactura = await (from c in _context.Set<DocumentosRelacionado>().AsNoTracking()
                                      where (c.TipoImportador == 9 || c.TipoImportador == 20) &&
                                            c.TipoExportador == 7 &&
                                            c.Exportador == pedido
                                      orderby c.IdenDocumentosrelacionados descending
                                      select c.Importador).FirstOrDefaultAsync();

            var numeroFactura = from f in _context.Set<FacturaDeCliente>().AsNoTracking()
                                where f.Consecutivo == consecutivoFactura &&
                                      f.Fecha >= Convert.ToDateTime("2024-01-01")
                                select f;

            var numeroRemision = from r in _context.Set<Remision>().AsNoTracking()
                                 where r.Consecutivo == consecutivoFactura &&
                                       r.Fecha >= Convert.ToDateTime("2024-01-01")
                                 select r;

            if (numeroFactura.Any()) return Ok(numeroFactura.FirstOrDefault());
            else if (numeroRemision.Any()) return Ok(numeroRemision.FirstOrDefault());
            else return NotFound();
#pragma warning restore CS8604 // Possible null reference argument.
        }

        [HttpPost("getFactura_PorPedidos")]
        public IActionResult GetFactura_PorPedidos([FromBody] List<string> pedidos)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var consecutivosFacturas =  
                                        (from c in _context.Set<DocumentosRelacionado>().AsNoTracking()
                                        where c.TipoImportador == 9 &&
                                            c.TipoExportador == 7 &&
                                            pedidos.Contains(Convert.ToString(c.Exportador))
                                        orderby c.IdenDocumentosrelacionados descending
                                        select c.Importador.ToString());

#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var numerosFacturas = (from f in _context.Set<FacturaDeCliente>().AsNoTracking()
                                  where consecutivosFacturas.Contains(f.Consecutivo.ToString())
                                  orderby Convert.ToInt32(f.Documento) descending
                                   select f.Documento);
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.


            if (numerosFacturas.Any()) return Ok(numerosFacturas);
            else return NotFound();
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
