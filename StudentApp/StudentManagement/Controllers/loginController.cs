using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class loginController : ControllerBase
    {
       
        public IActionResult Post(Students student)
        {
            using (var context = new StudentManagementDbContext())
            {
                var obj = context.Students.Single(t => t.Email == student.Email && t.Password == student.Password);
                if (obj != null)
                {
                    return Ok(obj.StudentId);
                }
                else
                {
                    return Ok("login failed");
                }



            }
        }
    }
}
