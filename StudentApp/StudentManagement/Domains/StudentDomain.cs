using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Domains
{
    public class StudentDomain:StudentManagementDbContext
    {
      
        public void addStudents(Students student)
        {
           

            using (var context = new StudentManagementDbContext())
            {
                var s = context.Database.ExecuteSqlCommand("sp_addStudent @name,@email,@mobileno,@courseid,@password",
                new SqlParameter("@name", student.StudentName),
                new SqlParameter("@mobileno", student.MobileNo),
                new SqlParameter("@email", student.Email),
                new SqlParameter("@password", student.Password),
                new SqlParameter("@courseid", student.CourseId)
                );



            }

        }

        public void updateStudents(Students student)
        {
            using (var context = new StudentManagementDbContext())
            {

                var s = context.Database.ExecuteSqlCommand("sp_updateStudent @name,@email,@mobileno,@password,@courseid,@id",
                new SqlParameter("@name", student.StudentName),
                new SqlParameter("@mobileno", student.MobileNo),
                new SqlParameter("@email", student.Email),
                new SqlParameter("@password", student.Password),
                new SqlParameter("@courseid", student.CourseId),

                new SqlParameter("@id", student.StudentId)
         
                );



            }
        }


        public void deleteStudent(int studentid)
        {
            using (var context = new StudentManagementDbContext())
            {

                var s = context.Database.ExecuteSqlCommand("sp_deleteStudent @id",
                new SqlParameter("@id", studentid)
                


                );



            }
        }
    }
}
