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
    public class CustomerController : ControllerBase
    {
        CustomerDomain customerDomain = new CustomerDomain();

        [HttpGet]
        public IActionResult Get(Customers customer)
        {
            return Ok(customerDomain.LoginCustomer(customer));
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int CustomerId)
        {
            using (var customerContext = new CustomerAppContext())
            {
                Customers customer = new Customers();
                
                var result = customerContext.Customers.Where(x=>x.CustomerId==customer.CustomerId);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok("Not Found");
                }
            }
        }

        [HttpPost]
        public IActionResult Post(Customers customer)
        {
            customerDomain.AddCustomer(customer);
            return Ok("Done Successfully");
        }


        [HttpPut]
        public IActionResult Put(Customers customer)
        {
            customerDomain.UpdateCustomer(customer);
            return Ok("Done Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            customerDomain.DeleteCustomer(id);
            return Ok("Done");
        }
    }
}