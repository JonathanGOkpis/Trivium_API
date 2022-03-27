using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trivium_API.Context;
using Trivium_API.Model;

namespace Trivium_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchasesController : ControllerBase
    {
        private readonly DataContext _context;
        public PurchasesController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Compra>>> GetPurcharses()
        {
            return await _context.Compra.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetPurcharse(int id)
        {
            return await _context.Compra.FindAsync(id);
        }
    }
}