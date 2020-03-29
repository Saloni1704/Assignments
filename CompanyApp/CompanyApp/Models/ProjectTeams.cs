using System;
using System.Collections.Generic;

namespace CompanyApp.Models
{
    public partial class ProjectTeams
    {
        public int ProjectTeamId { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeDesignation { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Projects Project { get; set; }
    }
}
