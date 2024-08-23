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
            /*optionsBuilder.UseSqlite(connectionString: "Filename=Inventario.db", sqliteOptionsAction: op =>
            {
                op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });*/
            base.OnConfiguring(optionsBuilder);
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Sale>().ToTable("Sales");
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            base.OnModelCreating(modelBuilder);
        }*/
    }
}
