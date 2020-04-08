using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Domains;
using StudentManagement.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeeController : ControllerBase
    {
        FeeDomain d = new FeeDomain();
        [HttpPost]
        public IActionResult Post(FeesPaid fee)
        {
            d.addFees(fee);
            return Ok(" Fee Added Succesfully");
        }
    }
}
