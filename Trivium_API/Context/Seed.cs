using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trivium_API.Model;

namespace Trivium_API.Context
{
    public class Seed
    {
        //Inserting dummy data for testing purpose
        public static async Task SeedData(DataContext context)
        {
            if (context.Cliente.Any()) return;
            
                List<Cliente> clientes = new List<Cliente> 
                {
                    new Cliente {
                        Nome = "Cliente 1",
                        Endereco = "Cidade A",
                        Telefone = "42 111111111"
                    },
                    new Cliente {
                        Nome = "Cliente 2",
                        Endereco = "Cidade B",
                        Telefone = "42 999999999"
                    },
                    new Cliente {
                        Nome = "Cliente 3",
                        Endereco = "Cidade C",
                        Telefone = "42 777777777"
                    },
                    new Cliente {
                        Nome = "Cliente 4",
                        Endereco = "Cidade D",
                        Telefone = "42 555555555"
                    },
                };
                await context.AddRangeAsync(clientes);
       
          
                List<Produto> produtos = new List<Produto>
                {
                    new Produto {
                        Nome = "Produto 1",
                        Preco = 10.99
                    },
                    new Produto {
                        Nome = "Produto 2",
                        Preco = 5.99
                    },
                    new Produto {
                        Nome = "Produto 3",
                        Preco = 3.71
                    },
                    new Produto {
                        Nome = "Produto 4",
                        Preco = 8.50
                    }
                };
              

          
        
                List<Compra> compras = new List<Compra>
                {
                    new Compra {
                        IDClient = 1,
                    },
                    new Compra {
                        IDClient = 2,
                    },
                    new Compra {
                        IDClient = 2,
                    },
                     new Compra {
                        IDClient = 2,
                    },
                    new Compra {
                        IDClient = 4,
                    },
                };
               
                List<CompraItem> compraItens = new List<CompraItem>
                {
                    new CompraItem{
                        IDCompra = 1,
                        IDProduto = 1,
                        Quantidade = 3
                    },
                     new CompraItem{
                        IDCompra = 2,
                        IDProduto = 2,
                        Quantidade = 16
                    },
                     new CompraItem{
                        IDCompra = 3,
                        IDProduto = 3,
                        Quantidade = 27
                    },
                        new CompraItem{
                        IDCompra = 4,
                        IDProduto = 3,
                        Quantidade = 5
                    },
                      new CompraItem{
                        IDCompra = 5,
                        IDProduto = 4,
                        Quantidade = 12
                    }
                    

                };
                await context.AddRangeAsync(clientes);
                await context.AddRangeAsync(produtos);
                await context.SaveChangesAsync();
                await context.AddRangeAsync(compras);
                await context.AddRangeAsync(compraItens);
                await context.SaveChangesAsync();           
        }
      
       
            

       
    }
}