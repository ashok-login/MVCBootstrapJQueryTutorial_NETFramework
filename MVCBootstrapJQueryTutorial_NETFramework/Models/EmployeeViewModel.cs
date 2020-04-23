using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBootstrapJQueryTutorial_NETFramework.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name can't be blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select department from the list")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Address can't be blank")]
        public string Address { get; set; }
        public string DepartmentName { get; set; }
        public bool Remember { get; set; }
    }
}
