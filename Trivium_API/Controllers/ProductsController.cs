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
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProducts()
        {
            List<Produto> products = await _context.Produto.ToListAsync();
            return Ok(products.Select(a=> new {
                a.ID,
                a.Nome,
                a.Preco
            }));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduct(int id)
        {
            Produto product = await _context.Produto.FindAsync(id);
            if (product is null) return NotFound("O produto informado não existe!");
            return Ok(new {product.ID, product.Nome, product.Preco});
        }
        //2. Busca de Compras para um Produto
        [HttpGet("profitByProduct/{id}")]
        public async Task<ActionResult> GetTotalFromProduct(int id)
        {
            var product = await _context.Produto.FindAsync(id);
            if (product is null) return NotFound("Produto não existe!");
            double totalBought = 0;
            double totalValue = 0;
            foreach(var compra in _context.CompraItem.Where(a=> a.IDProduto == product.ID))
            {
                totalBought += compra.Quantidade;
                totalValue += compra.Quantidade * product.Preco;
            }
            return Ok(new {totalBought, totalValue});
        }
        //3. Busca de Compras por Produto
        [HttpGet("profitByPurchase")]
        public async Task<ActionResult> GetProfitByPurchase()
        {
            var products = await _context.Produto.ToListAsync();
            foreach(var item in products)
            {
                foreach (var compra in _context.CompraItem.Where(a=> a.IDProduto == item.ID))
                {
                    item.TotalCompras += compra.Quantidade;
                    item.TotalArrecadado += compra.Quantidade * item.Preco;
                }
            };
            return Ok(products);
        }
    }
}