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

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> Get(string id)
        {
            return await _productTypesService.GetProductType(id);
        }

    }
}