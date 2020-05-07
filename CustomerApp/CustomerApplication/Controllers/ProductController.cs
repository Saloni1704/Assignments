using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApplication.Domain;
using CustomerApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductDomain productDomain = new ProductDomain();
        [HttpGet]
        public IActionResult Get(Products product)
        {
            
            return Ok(productDomain.AllProduct(product));
        }

        [HttpPost]

        public IActionResult Post(Products product)
        {
            productDomain.AddProduct(product);
            return Ok("Ok");
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            productDomain.DeleteProduct(id);
            return Ok("Ok");
        }
    }
}