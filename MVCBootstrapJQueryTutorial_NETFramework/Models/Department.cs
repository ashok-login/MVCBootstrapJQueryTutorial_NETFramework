using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBootstrapJQueryTutorial_NETFramework.Models
{
    [Table("Department")]
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}