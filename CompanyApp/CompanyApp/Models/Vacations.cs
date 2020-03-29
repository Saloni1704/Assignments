using System;
using System.Collections.Generic;

namespace CompanyApp.Models
{
    public partial class Vacations
    {
        public int VacationId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
