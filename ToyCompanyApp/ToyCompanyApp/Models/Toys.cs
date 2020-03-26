using System;
using System.Collections.Generic;

namespace ToyCompanyApp.Models
{
    public partial class Toys
    {
        public Toys()
        {
            Orders = new HashSet<Orders>();
        }

        public int ToyId { get; set; }
        public string ToyName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int PlantId { get; set; }

        public virtual ToyCategory Category { get; set; }
        public virtual Plants Plant { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
