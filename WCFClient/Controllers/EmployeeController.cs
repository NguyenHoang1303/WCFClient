using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFClient.ServiceReference1;

namespace WCFClient.Controllers
{
    public class EmployeeController : Controller
    {
        private Service1Client service;

        public EmployeeController()
        {
            service = new Service1Client();
        }
        // GET: Employee
        public ActionResult Index(string deparment)
        {
            if (string.IsNullOrEmpty(deparment))
            {
                return View(service.FindAll());
            }
            ViewBag.CurrentFilter = deparment;
            return View(service.FindEmployeeByDepartment(deparment));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (service.Save(employee) == null)
                {
                    return RedirectToAction("Create");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
