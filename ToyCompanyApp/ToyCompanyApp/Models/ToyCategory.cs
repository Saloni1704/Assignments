using System;
using System.Collections.Generic;

namespace ToyCompanyApp.Models
{
    public partial class ToyCategory
    {
        public ToyCategory()
        {
            Toys = new HashSet<Toys>();
        }

        public int ToyCategoryId { get; set; }
        public string ToyCategoryName { get; set; }

        public virtual ICollection<Toys> Toys { get; set; }
    }
}
