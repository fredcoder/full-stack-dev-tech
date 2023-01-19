using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDev.Context;
using FullStackDev.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FullStackDev.Services
{
    public class ProductsService : IProductsService
    {
        public readonly WebApiContext _webApiContext;
        private readonly ILogger<ProductsService> _logger;
        public ProductsService(WebApiContext context, ILogger<ProductsService> logger)
        {
            _logger = logger;
            _webApiContext = context;
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
                _logger.LogInformation("Added: {newProduct}", newProduct.ToString());
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
                _logger.LogInformation("Updated: {id}", product.Id);
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
                _logger.LogInformation("Deleted: {oldProduct}", oldProduct);
            });
            _webApiContext.SaveChanges();
        }
    }
}