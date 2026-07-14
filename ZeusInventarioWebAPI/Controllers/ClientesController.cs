using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        // Función para obtener todos los clientes
        [HttpGet("getClientByName/{name}")]
        public async Task<ActionResult> getClientByName(string name)
        {
            var clients = await (from c in _context.Set<Cliente>().AsNoTracking()
                                 where c.Razoncial.Contains(name)
                                 select c).ToListAsync();

            return clients.Any() ? Ok(clients) : NotFound();
        }

        // Función para obtener un cliente por su ID
        [HttpGet("getClientById/{id}")]
        public async Task<ActionResult> getClientById(string id)
        {
            var client = await (from c in _context.Set<Cliente>().AsNoTracking()
                                where c.Idtercero == id
                                select c).ToListAsync();

            return client.Any() ? Ok(client) : NotFound();
        }

        // Función para obtener un cliente por su ID de tercero
        [HttpGet("getClientByIdThird/{third}")]
        public async Task<ActionResult> getClientBythird(string third)
        {
            var client = await
                         (from c in _context.Set<Cliente>().AsNoTracking()
                          where c.Idcliente == third
                         select c).ToListAsync();

            return client.Any() ? Ok(client) : NotFound();
        }
    }
}
