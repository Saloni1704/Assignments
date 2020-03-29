using System;
using System.Collections.Generic;

namespace CompanyApp.Models
{
    public partial class Projects
    {
        public Projects()
        {
            ProjectTeams = new HashSet<ProjectTeams>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int BusinessUnitId { get; set; }

        public virtual BusinessUnits BusinessUnit { get; set; }
        public virtual ICollection<ProjectTeams> ProjectTeams { get; set; }
    }
}
