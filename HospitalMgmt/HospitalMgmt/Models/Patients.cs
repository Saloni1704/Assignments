using System;
using System.Collections.Generic;

namespace HospitalMgmt.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
            Treatments = new HashSet<Treatments>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string ContactNumber { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Disease { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Treatments> Treatments { get; set; }
    }
}
