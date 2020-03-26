using System;
using System.Collections.Generic;

namespace HospitalMgmt.Models
{
    public partial class Drugs
    {
        public Drugs()
        {
            Treatments = new HashSet<Treatments>();
        }

        public int DrugId { get; set; }
        public string DrugName { get; set; }

        public virtual ICollection<Treatments> Treatments { get; set; }
    }
}
