using System;
using System.Collections.Generic;

namespace CompanyApp.Models
{
    public partial class Employees
    {
        public Employees()
        {
            ProjectTeams = new HashSet<ProjectTeams>();
            Vacations = new HashSet<Vacations>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public int BusinessUnitId { get; set; }
        public int EmployeeCode { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual ICollection<ProjectTeams> ProjectTeams { get; set; }
        public virtual ICollection<Vacations> Vacations { get; set; }
    }
}
