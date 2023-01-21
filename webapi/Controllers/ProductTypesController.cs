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
    public class ProductTypesController : ControllerBase
    {
        public readonly IProductTypesService _productTypesService;

        public ProductTypesController(IProductTypesService productTypesService)
        {
            _productTypesService = productTypesService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> Get()
        {
            var productTypes = await _productTypesService.GetProductTypes();
            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> Get(string id)
        {
            var productType = await _productTypesService.GetProductType(id);
            if (productType == null)
            {
                return NotFound();
            }
            return Ok(productType);
        }
    }

}