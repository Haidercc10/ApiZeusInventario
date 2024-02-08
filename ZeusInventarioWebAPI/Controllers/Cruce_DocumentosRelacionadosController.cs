using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult GetFactura(decimal pedido)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var consecutivoFactura = (from c in _context.Set<DocumentosRelacionado>()
                                      where (c.TipoImportador == 9 || c.TipoImportador == 20) &&
                                            c.TipoExportador == 7 &&
                                            c.Exportador == pedido
                                      orderby c.IdenDocumentosrelacionados descending
                                      select c.Importador).FirstOrDefault();

            var numeroFactura = from f in _context.Set<FacturaDeCliente>()
                                where f.Consecutivo == consecutivoFactura &&
                                      f.Fecha >= Convert.ToDateTime("2024-01-01")
                                select f;

            var numeroRemision = from r in _context.Set<Remision>()
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
            var consecutivoFactura = (from c in _context.Set<DocumentosRelacionado>()
                                      where (c.TipoImportador == 9 || c.TipoImportador == 20) &&
                                            c.TipoExportador == 7 &&
                                            pedidos.Contains(Convert.ToString(c.Exportador))
                                      orderby c.IdenDocumentosrelacionados descending
                                      select c.Importador).FirstOrDefault();

            var numeroFactura = from f in _context.Set<FacturaDeCliente>()
                                where f.Consecutivo == consecutivoFactura
                                select f;

            var numeroRemision = from r in _context.Set<Remision>()
                                 where r.Consecutivo == consecutivoFactura
                                 select r;

            if (numeroFactura.Any()) return Ok(numeroFactura.FirstOrDefault());
            else if (numeroRemision.Any()) return Ok(numeroRemision.FirstOrDefault());
            else return NotFound();
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
