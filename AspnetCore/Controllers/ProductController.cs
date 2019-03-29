using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Infrastructure;
using DataModels.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IproductBusiness _productBusiness { get; set; }

        public ProductController(IproductBusiness productBusiness)
        {
            this._productBusiness = productBusiness;
        }

        [HttpGet]
        [Route("getallproducts")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var result = await _productBusiness.GetAllProduct();

            if (!result.Any()) return NotFound();

            return Ok(result);
        }
    }
}