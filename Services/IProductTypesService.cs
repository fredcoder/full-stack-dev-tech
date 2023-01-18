using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDev.Models;

namespace FullStackDev.Services
{
    public interface IProductTypesService
    {
        public Task<ProductType> GetProductType(string id);
    }
}