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
    public class SearchProductController : ControllerBase
    {
        ProductDomain productDomain = new ProductDomain();
        [HttpGet]
        public IActionResult Get(Products product)
        {
            productDomain.SearchProduct(product);
            return Ok("OK");
        }
    }
}