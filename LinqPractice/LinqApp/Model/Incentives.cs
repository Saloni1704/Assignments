using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqApp.Model
{
    public partial class Incentives
    {
        [Key]
        public int IncentiveId { get; set; }
        public int EmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime IncentiveDate { get; set; }
        public int IncentiveAmount { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Employees.Incentives))]
        public virtual Employees Employee { get; set; }
    }
}
