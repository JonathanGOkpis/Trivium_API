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
    public class ClientsController : ControllerBase
    {
        private readonly DataContext _context;
        public ClientsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetClients()
        {
            return await _context.Cliente.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClient(int id)
        {
            Cliente client = await _context.Cliente.FindAsync(id);
            if (client is null) return NotFound("Cliente não existe!");
            return client;
        }
        [HttpPost]
        public async Task<IActionResult> CreateClient(Cliente cliente)
        {
            await _context.Cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateClient(Cliente cliente)
        {
            var client = await _context.Cliente.FindAsync(cliente.ID);
            if(client is null) return NotFound("Cliente não existe!");
            client.Nome = cliente.Nome ?? client.Nome;
            client.Endereco = cliente.Endereco ?? client.Endereco;
            client.Telefone = cliente.Telefone ?? client.Telefone;
            await _context.SaveChangesAsync();
            return Ok(client);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Cliente.FindAsync(id);
            if(client is null) return NotFound("Cliente não existe!");
            _context.Cliente.Remove(client);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //1. Busca de Compras para um Cliente
        [HttpGet("purchases/{id}")]
        public async Task<ActionResult> GetPurchasesByClient(int id)
        {
      
            Cliente client = await _context.Cliente.FindAsync(id);
            if (client is null) return NotFound("Cliente não existe!");
            List<Compra> purchases = new List<Compra>();
            List<CompraItem> items_purchased = new List<CompraItem>();
            List<Produto> products = await _context.Produto.ToListAsync();
           
            purchases = await _context.Compra.Where(a=> a.IDClient == client.ID).ToListAsync();
            if (purchases.Count == 0) return NotFound("Cliente não possui compras!");
            foreach (var compra in purchases)
            {
                items_purchased.AddRange(_context.CompraItem.Where(a=> a.IDCompra == compra.ID));
            }
            foreach(var item in items_purchased)
            {
                item.valorTotalCompra = item.Quantidade * item.Produto.Preco;
            }
            return Ok(items_purchased.Select(a=> new {
                a.ID,
                a.IDCompra,
                a.IDProduto,
                a.Produto.Nome,
                a.Produto.Preco,
                a.Quantidade,
                a.valorTotalCompra
            }));
        }
        //4. Busca de Produtos mais comprados para um Cliente
        [HttpGet("mostbought/{id}")]
        public async Task<ActionResult<List<Produto>>> GetMostBoughtProducts(int id) 
        {
            Cliente customer = await _context.Cliente.FindAsync(id);
            if(customer is null) return NotFound("Cliente não existe!");
            List<Compra> purchases = new List<Compra>();
            purchases = await _context.Compra.Where(a=> a.IDClient == id).ToListAsync();
            var productsList = await _context.Produto.ToListAsync();
            List<Produto> products = new List<Produto>();
           foreach(var item in purchases)
            {
                foreach (var compra in _context.CompraItem.Where(a=> a.IDCompra == item.ID).GroupBy(a=> a.IDProduto).Select(a=> a.First()))
                {
                    products.Add(new Produto(){
                        Nome = compra.Produto.Nome,
                        TotalCompras = _context.CompraItem.Where(a=> a.IDCompra == item.ID && a.IDProduto == compra.IDProduto).Sum(a=> a.Quantidade)
                    });
                    // item.TotalCompras += compra.Quantidade;
                }
            };
            products = products.OrderByDescending(a=> a.TotalCompras).Take(5).ToList();
            return Ok(products.Select(a=> new {a.Nome, a.TotalCompras}));
            
        }
        
    }
}