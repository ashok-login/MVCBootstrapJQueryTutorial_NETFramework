using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult CreaateEmployee()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateEmployee()
        {
            var details = "test";
            return Json(details);
        }
    }
}
