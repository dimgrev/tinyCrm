using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Data
{
    public class TinyCrmDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost;Database=TinyCrmDb;User Id=sa;Password=admin!@#123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Database.EnsureCreated();

            modelBuilder
                .Entity<Customer>()
                .ToTable("Customer");

            modelBuilder
                .Entity<Product>()
                .ToTable("Product");

            modelBuilder
                .Entity<Order>()
                .ToTable("Order");

            modelBuilder
                .Entity<OrderProduct>()
                .ToTable("OrderProduct");

            modelBuilder
                .Entity<OrderProduct>()
                .HasKey(op => new { op.ProductId, op.OrderId });
        }
    }
}
