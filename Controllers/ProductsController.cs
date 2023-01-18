using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackDev.Models;
using FullStackDev.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullStackDev.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _productsService.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            return await _productsService.GetProduct(id);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            return await _productsService.PostProduct(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(string id, [FromBody] Product product)
        {
            return await _productsService.PutProduct(id, product);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _productsService.DeleteProduct(id);
        }
    }
}