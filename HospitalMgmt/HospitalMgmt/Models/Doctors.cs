using System;
using System.Collections.Generic;

namespace HospitalMgmt.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
            Treatments = new HashSet<Treatments>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Treatments> Treatments { get; set; }
    }
}
