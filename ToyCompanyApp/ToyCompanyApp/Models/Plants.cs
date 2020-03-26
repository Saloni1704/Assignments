using System;
using System.Collections.Generic;

namespace ToyCompanyApp.Models
{
    public partial class Plants
    {
        public Plants()
        {
            Toys = new HashSet<Toys>();
        }

        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Toys> Toys { get; set; }
    }
}
