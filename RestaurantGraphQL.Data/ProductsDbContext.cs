using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestaurantGraphQL.Core.Models;

namespace RestaurantGraphQL.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options)
        { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .Property(e => e.Unit)
                .HasConversion<string>()
                .HasMaxLength(4);

            modelBuilder
                .Entity<Product>()
                .Property(e => e.Title)
                .HasMaxLength(255);

            modelBuilder
                .Entity<Product>()
                .Ignore(e => e.UnitEnum);

            modelBuilder
                .Entity<Category>()
                .Property(e => e.Title)
                .HasMaxLength(255);

            modelBuilder
                .Entity<ProductImage>()
                .Property(e => e.Path)
                .HasMaxLength(500);
        }
    }
}