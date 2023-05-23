﻿using Microsoft.EntityFrameworkCore;
using Sales.Domain.Domain_Entities;

namespace Sales.Persistence.Persist_DbContext
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(
                new Product { id = Guid.NewGuid(), createDate = DateTime.Now, maxLevel = 100, minLevel = 10, name = "Monitor", taxRate = 10, origin = "USA" },
                new Product { id = Guid.NewGuid(), createDate = DateTime.Now, maxLevel = 90, minLevel = 9, name = "Mouse", taxRate = 11, origin = "GERMANY" },
                new Product { id = Guid.NewGuid(), createDate = DateTime.Now, maxLevel = 80, minLevel = 8, name = "Keyboard", taxRate = 12, origin = "ITALY" },
                new Product { id = Guid.NewGuid(), createDate = DateTime.Now, maxLevel = 70, minLevel = 7, name = "HDMI Cable", taxRate = 13, origin = "FRANCE" },
                new Product { id = Guid.NewGuid(), createDate = DateTime.Now, maxLevel = 60, minLevel = 6, name = "TouchScreen", taxRate = 14, origin = "JAPAN" },
                new Product { id = Guid.NewGuid(), createDate = DateTime.Now, maxLevel = 50, minLevel = 5, name = "Extarnal HDD", taxRate = 15, origin = "CHINA" },
                new Product { id = Guid.NewGuid(), createDate = DateTime.Now, maxLevel = 40, minLevel = 4, name = "Ram", taxRate = 16, origin = "UK" }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
