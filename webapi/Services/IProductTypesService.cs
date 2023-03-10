using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public interface IProductTypesService
    {
        public Task<ProductType> GetProductType(string id);
        public Task<List<ProductType>> GetProductTypes();
    }
}