using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Domains
{
    public class FeeDomain
    {
        public void addFees(FeesPaid fee)
        {
            

                using (var context = new StudentManagementDbContext())
                {

                    var s = context.Database.ExecuteSqlCommand("sp_addFees @feeamount,@id",
                    new SqlParameter("@feeamount", fee.FeeAmount),
                    new SqlParameter("@id", fee.StudentId)
                    
                    );



                }

            
        }
    }
}
