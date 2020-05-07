using System;
using System.Collections.Generic;

namespace CustomerApplication.Models
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public int CustomerNumber { get; set; }
    }
}
