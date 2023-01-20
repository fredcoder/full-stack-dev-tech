using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Context;
using webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace webapi.Services
{
    public class ProductsService : IProductsService
    {
        public readonly WebApiContext _webApiContext;
        public ProductsService(WebApiContext context)
        {
            _webApiContext = context;
            _webApiContext.Database.EnsureCreated();
        }

        public async Task<Product> GetProduct(string id)
        {
            var product = new Product();
            await Task.Run(() =>
            {
                product = _webApiContext.Products.Include(p => p.ProductType)
                                                 .FirstOrDefault(p => p.Id == id);
            });
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = new List<Product>();
            await Task.Run(() =>
            {
                products = _webApiContext.Products.Include(p => p.ProductType)
                                                  .ToList();
            });
            return products;
        }

        public async Task<Product> PostProduct(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            await Task.Run(() =>
            {
                var newProduct = _webApiContext.Products.AddAsync(product);
            });
            _webApiContext.SaveChanges();

            return product;
        }

        public async Task<Product> PutProduct(string id, Product newProduct)
        {
            var product = new Product();
            await Task.Run(() =>
            {
                product = _webApiContext.Products.FirstOrDefault(p => p.Id == id);
                product.Name = newProduct.Name;
                product.Price = newProduct.Price;
                product.IsActive = newProduct.IsActive;
                product.ProductTypeId = newProduct.ProductTypeId;
            });
            _webApiContext.SaveChanges();

            return product;
        }

        public async Task DeleteProduct(string id)
        {
            var product = new Product();
            await Task.Run(() =>
            {
                product = _webApiContext.Products.FirstOrDefault(p => p.Id == id);
                var oldProduct = _webApiContext.Products.Remove(product);
            });
            _webApiContext.SaveChanges();
        }
    }
}