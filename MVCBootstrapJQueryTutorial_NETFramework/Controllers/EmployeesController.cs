using MVCBootstrapJQueryTutorial_NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
//Stop doing undo
namespace MVCBootstrapJQueryTutorial_NETFramework.Controllers
{
    public class EmployeesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateEmployee()
        {
            FillDepartmentsDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee();
                emp.Name = model.Name;
                emp.Address = model.Address;
                emp.DepartmentId = model.DepartmentId;
                var db = new MyDatabaseContext();
                Thread.Sleep(3000);
                db.Employees.Add(emp);
                db.SaveChanges();
            }
            FillDepartmentsDropdownList();
            return View();
        }

        private void FillDepartmentsDropdownList()
        {
            var db = new MyDatabaseContext();
            var departments = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
        }

    }
}
