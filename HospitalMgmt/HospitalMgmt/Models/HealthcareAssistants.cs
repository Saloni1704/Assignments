using System;
using System.Collections.Generic;

namespace HospitalMgmt.Models
{
    public partial class HealthcareAssistants
    {
        public HealthcareAssistants()
        {
            AssignAssistants = new HashSet<AssignAssistants>();
        }

        public int AssistantId { get; set; }
        public string AssistantName { get; set; }
        public int DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<AssignAssistants> AssignAssistants { get; set; }
    }
}
