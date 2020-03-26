using System;
using System.Collections.Generic;

namespace HospitalMgmt.Models
{
    public partial class Treatments
    {
        public int PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Timing { get; set; }
        public int DrugId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Drugs Drug { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
