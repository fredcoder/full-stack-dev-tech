using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDev.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackDev.Context
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<ProductType> productTypes = new List<ProductType>();
            productTypes.Add(new ProductType { Id = "b00db9eb-7650-4878-b814-8a96d5a8220e", Name = "Books" });
            productTypes.Add(new ProductType { Id = "f30e74cd-2494-4fc8-8eb3-8de05c4a821e", Name = "Electronics" });
            productTypes.Add(new ProductType { Id = "070e30e7-488b-47e3-ad28-4379b9be6185", Name = "Food" });
            productTypes.Add(new ProductType { Id = "74ca9e4c-2f51-4bfb-8ee0-12efe0db187f", Name = "Furniture" });
            productTypes.Add(new ProductType { Id = "d6d124a9-df5b-4ae8-848d-d15bb33bbd19", Name = "Toys" });

            builder.Entity<ProductType>().ToTable("ProductType").HasKey(p => p.Id);
            builder.Entity<ProductType>().ToTable("ProductType").HasData(productTypes);

            List<Product> products = new List<Product>();
            products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Don Quixote", Price = 12.00F, ProductTypeId = productTypes[0].Id, Active = true });
            products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Microwave", Price = 30.00F, ProductTypeId = productTypes[1].Id, Active = true });
            products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Pizza", Price = 15.00F, ProductTypeId = productTypes[2].Id, Active = true });
            products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Chair", Price = 25.00F, ProductTypeId = productTypes[3].Id, Active = true });
            products.Add(new Product { Id = Guid.NewGuid().ToString(), Name = "Lego", Price = 30.00F, ProductTypeId = productTypes[4].Id, Active = true });


            builder.Entity<Product>().ToTable("Product").HasKey(p => p.Id);
            builder.Entity<Product>().ToTable("Product").HasData(products);

            builder.Entity<Product>().HasOne<ProductType>("ProductType");

        }

    }
}