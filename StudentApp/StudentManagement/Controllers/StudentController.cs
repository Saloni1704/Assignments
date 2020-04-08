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
    public class StudentController : ControllerBase
    {
        StudentDomain d = new StudentDomain();

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = new StudentManagementDbContext())
            {
                var obj = context.Students.Single(t => t.StudentId == id);
                return Ok(obj);
            }
        }


        [HttpPost]
        public IActionResult Post(Students student)
        {
           d.addStudents(student);
            return Ok("Added Succesfully");
        }

        [HttpPut]
        public IActionResult Put(Students student)
        {
            d.updateStudents(student);
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            d.deleteStudent(id);
            return Ok("Removed Successfully");
        }
    }
}
