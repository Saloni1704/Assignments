using System;
using System.Collections.Generic;

namespace HospitalMgmt.Models
{
    public partial class Appointments
    {
        public Appointments()
        {
            AssignAssistants = new HashSet<AssignAssistants>();
        }

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentTime { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual ICollection<AssignAssistants> AssignAssistants { get; set; }
    }
}
