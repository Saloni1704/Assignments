using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Students
    {
        public Students()
        {
            FeesPaid = new HashSet<FeesPaid>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int CourseId { get; set; }
        public string Password { get; set; }
        public virtual ICollection<FeesPaid> FeesPaid { get; set; }
    }
}
