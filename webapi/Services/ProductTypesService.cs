using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Context;
using webapi.Models;
using Microsoft.Extensions.Logging;

namespace webapi.Services
{
    public class ProductTypesService : IProductTypesService
    {
        public readonly WebApiContext _webApiContext;
        private readonly ILogger<ProductTypesService> _logger;
        public ProductTypesService(WebApiContext context, ILogger<ProductTypesService> logger)
        {
            _logger = logger;
            _webApiContext = context;
        }

        public async Task<ProductType> GetProductType(string id)
        {
            var productType = new ProductType();
            await Task.Run(() =>
            {
                productType = _webApiContext.ProductTypes.FirstOrDefault(p => p.Id == id);
            });
            return productType;
        }
    }
}