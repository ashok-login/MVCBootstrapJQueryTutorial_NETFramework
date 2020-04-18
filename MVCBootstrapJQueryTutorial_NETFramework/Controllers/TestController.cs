using MVCBootstrapJQueryTutorial_NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBootstrapJQueryTutorial_NETFramework.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            MyDatabaseEntities db = new MyDatabaseEntities();
            List<Department> departments = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "DepartmentId", "Name");
            return View();
        }

        public ActionResult SaveRecord(EmployeeViewModel model)
        {
            try
            {
                MyDatabaseEntities db = new MyDatabaseEntities();
                var emp = new Employee()
                {
                    Name = model.Name,
                    DepartmentId = model.DepartmentId,
                    Address = model.Address
                };
                db.Employees.Add(emp);
                db.SaveChanges();
                int latestInsertedEmpId = emp.EmployeeId;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
