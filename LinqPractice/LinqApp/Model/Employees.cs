using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqApp.Model
{
    public partial class Employees
    {
        public Employees()
        {
            Incentives = new HashSet<Incentives>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        public int Salary { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime JoiningDate { get; set; }
        [Required]
        [StringLength(20)]
        public string Department { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<Incentives> Incentives { get; set; }
    }
}
