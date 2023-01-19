using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;
using webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
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
            var products = await _productsService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _productsService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            var newProduct = new Product();
            try
            {
                newProduct = await _productsService.PostProduct(product);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("PostProduct Error", e.Message);
                return BadRequest(ModelState);
            }
            return Created(new Uri($"{Request.Path}/{newProduct.Id}", UriKind.Relative), newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(string id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                ModelState.AddModelError("PutProduct Error", "Mismatched Ids");
                return BadRequest(ModelState);
            }

            try
            {
                var prod = await _productsService.GetProduct(id);
                if (prod == null)
                {
                    ModelState.AddModelError("PutProduct Error", "Product does not exist");
                    return BadRequest(ModelState);
                }
                await _productsService.PutProduct(id, product);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("PutProduct Error", e.Message);
                return BadRequest(ModelState);
            }
            return Accepted(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var prod = await _productsService.GetProduct(id);
                if (prod == null)
                {
                    ModelState.AddModelError("DeleteProduct Error", "Product does not exist");
                    return BadRequest(ModelState);
                }

                await _productsService.DeleteProduct(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("DeleteProduct Error", e.Message);
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}