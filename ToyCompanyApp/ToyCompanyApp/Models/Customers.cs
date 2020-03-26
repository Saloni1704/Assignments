using System;
using System.Collections.Generic;

namespace ToyCompanyApp.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
