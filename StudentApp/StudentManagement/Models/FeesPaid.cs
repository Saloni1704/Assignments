using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class FeesPaid
    {
        public int FeeId { get; set; }
        public double FeeAmount { get; set; }
        public DateTime FeeDate { get; set; }
        public int StudentId { get; set; }

        public virtual Students Student { get; set; }
    }
}
