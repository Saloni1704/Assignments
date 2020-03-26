using System;
using System.Collections.Generic;

namespace ToyCompanyApp.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ToyId { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Toys Toy { get; set; }
    }
}
