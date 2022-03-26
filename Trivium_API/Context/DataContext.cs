using Microsoft.EntityFrameworkCore;
using Trivium_API.Model;

namespace Trivium_API.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CompraItem> CompraItem { get; set; }
    }
}
