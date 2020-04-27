using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBootstrapJQueryTutorial_NETFramework.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }

        public Department Department { get; set; }
    }
}
