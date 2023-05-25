using Microsoft.EntityFrameworkCore;
using Sales.Domain.Domain_Entities;

namespace Sales.Persistence.Persist_DbContext
{
    public class AppDbContext : DbContext
    {
        private static bool isDatabaseSeeded = false;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products").HasKey(p => p.id);

            if (!isDatabaseSeeded)
            {
                
                // Seed data
                modelBuilder.Entity<Product>().HasData(
                    new Product { id = Guid.NewGuid(), name = "Product1" },
                    new Product { id = Guid.NewGuid(), name = "Product2" }
                );
                isDatabaseSeeded = true;
            }

            base.OnModelCreating(modelBuilder);
        }



    }
}
