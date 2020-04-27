using MVCBootstrapJQueryTutorial_NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult ManageEmployee(EmployeeViewModel model)
        {
            var db = new MyDatabaseContext();
            var employees = db.Employees
                        .Where(x => x.IsDeleted == false)
                        .Select(x=> new EmployeeViewModel {
                            EmployeeId = x.EmployeeId,
                            Name = x.Name,
                            DepartmentId = x.DepartmentId,
                            DepartmentName = x.Department.DepartmentName,
                            Address = x.Address
                        })
                        .ToList();
            ViewBag.EmployeeList = employees;
            return View();
        }

        public JsonResult DeleteEmployee(int EmployeeId)
        {
            var db = new MyDatabaseContext();
            bool result = false;
            Employee emp = db.Employees
                            .SingleOrDefault(x => x.IsDeleted == false &&
                                    x.EmployeeId == EmployeeId);
            if(emp != null)
            {
                emp.IsDeleted = true;
                Thread.Sleep(5000);
                // db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewEmployees()
        {
            var db = new MyDatabaseContext();
            var employees = db.Employees
                        .Where(x => x.IsDeleted == false)
                        .Select(x => new EmployeeViewModel {
                            EmployeeId = x.EmployeeId,
                            Name = x.Name,
                            Address = x.Address,
                            DepartmentId = x.DepartmentId,
                            DepartmentName = x.Department.DepartmentName
                        })
                        .ToList();
            ViewBag.EmployeesList = employees;
            return View();
        }

        public ActionResult GetEmployeeById(int empId)
        {
            var db = new MyDatabaseContext();
            var emp = db.Employees
                    .Where(x => x.EmployeeId == empId)
                    .Select(x => new EmployeeViewModel { 
                        EmployeeId = x.EmployeeId,
                        Name = x.Name,
                        Address = x.Address,
                        DepartmentId = x.DepartmentId,
                        DepartmentName = x.Department.DepartmentName
                    })
                    .SingleOrDefault();
            return PartialView("_ShowEmployeeByIdPartialView", emp);
        }

        public ActionResult ShowEmployeesPartialView()
        {
            return PartialView("_EmployeesPartialView");
        }

        private void FillDepartmentsDropdownList()
        {
            var db = new MyDatabaseContext();
            var departments = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
        }

    }
}
