using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class EmployeeController : Controller
    {
        ZoolandiaRazorRepo repo = new ZoolandiaRazorRepo();
        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.Employee = repo.GetAllEmployees();
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Exhibits = repo.GetAllExhibits();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                repo.AddNewEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpDelete]
        public ActionResult Delete(Employee employee)
        {
            if (ModelState.IsValid)
            {
                repo.RemoveEmployeeByFirstName(employee.FirstName);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
