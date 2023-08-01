using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeusInventarioWebAPI.Data;
using ZeusInventarioWebAPI.Models;

namespace ZeusInventarioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
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

    }
}
