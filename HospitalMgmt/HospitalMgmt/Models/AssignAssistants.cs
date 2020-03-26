using System;
using System.Collections.Generic;

namespace HospitalMgmt.Models
{
    public partial class AssignAssistants
    {
        public int AssignAssistantId { get; set; }
        public int AssistantId { get; set; }
        public int AppointmentId { get; set; }

        public virtual Appointments Appointment { get; set; }
        public virtual HealthcareAssistants Assistant { get; set; }
    }
}
