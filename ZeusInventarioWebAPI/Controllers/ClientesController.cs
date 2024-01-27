using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZeusInventarioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly Data.InventarioDataContext _context;

        public ClientesController(Data.InventarioDataContext context)
        {
            _context = context;
        }

        [HttpGet("getClientByName/{name}")]
        public ActionResult getClientBtName(string name)
        {
            var clients = from c in _context.Set<Cliente>()
                          where c.Razoncial.Contains(name)
                          select c;
            return clients.Any() ? Ok(clients) : NotFound();
        }

        [HttpGet("getClientById/{id}")]
        public ActionResult getClientById(string id)
        {
            var client = from c in _context.Set<Cliente>()
                         where c.Idtercero == id
                         select c;
            return client.Any() ? Ok(client) : NotFound();
        }

        [HttpGet("getClientByIdThird/{third}")]
        public ActionResult getClientBythird(string third)
        {
            var client = from c in _context.Set<Cliente>()
                         where c.Idcliente == third
                         select c;
            return client.Any() ? Ok(client) : NotFound();
        }
    }
}
