using System;
using System.Collections.Generic;

namespace CompanyApp.Models
{
    public partial class BusinessUnits
    {
        public BusinessUnits()
        {
            Employees = new HashSet<Employees>();
            Projects = new HashSet<Projects>();
        }

        public int BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
