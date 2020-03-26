using System;
using System.Collections.Generic;

namespace HospitalMgmt.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Doctors = new HashSet<Doctors>();
            HealthcareAssistants = new HashSet<HealthcareAssistants>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Doctors> Doctors { get; set; }
        public virtual ICollection<HealthcareAssistants> HealthcareAssistants { get; set; }
    }
}
