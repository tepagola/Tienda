using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tienda.Models;

namespace Tienda.Data
{
    internal class InventarioContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Inventario.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
