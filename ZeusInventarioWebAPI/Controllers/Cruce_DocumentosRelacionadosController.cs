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
            var consecutivoFactura = (from c in _context.Set<CruceDocumentosRelacionado>()
                                      where c.TipoImportador == 9 &&
                                            c.TipoExportador == 7 &&
                                            c.Exportador == pedido
                                      orderby c.SpId descending
                                      select c.Importador).FirstOrDefault();

            var numeroFactura = from f in _context.Set<FacturaDeCliente>()
                                where f.Consecutivo == consecutivoFactura
                                select f;

            return numeroFactura.Any() ? Ok(numeroFactura.FirstOrDefault()) : NotFound();
#pragma warning restore CS8604 // Possible null reference argument.
        }

        [HttpPost("getFactura_PorPedidos")]
        public IActionResult GetFactura_PorPedidos([FromBody] List<string> pedidos)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var consecutivoFactura = (from c in _context.Set<CruceDocumentosRelacionado>()
                                      where c.TipoImportador == 9 &&
                                            c.TipoExportador == 7 /*&&
                                            pedidos.Contains(Convert.ToString(c.Exportador))*/
                                      orderby c.SpId descending
                                      select c.Importador).FirstOrDefault();

            var numeroFactura = from f in _context.Set<FacturaDeCliente>()
                                where f.Consecutivo == consecutivoFactura
                                select f;

            return numeroFactura.Any() ? Ok(numeroFactura.FirstOrDefault()) : NotFound();
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
