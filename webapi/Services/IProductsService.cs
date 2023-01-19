using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public interface IProductsService
    {
        public Task<Product> GetProduct(string id);
        public Task<List<Product>> GetProducts();
        public Task<Product> PostProduct(Product product);
        public Task<Product> PutProduct(string id, Product newProduct);
        public Task DeleteProduct(string id);
    }
}