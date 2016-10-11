using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class ExhibitsController : Controller
    {
        ZoolandiaRazorRepo repo = new ZoolandiaRazorRepo();

        // GET: Exhibits
        public ActionResult Index()
        {
            ViewBag.All_Exhibits = repo.GetAllExhibits();
            return View();
                
        }

        // GET: Exhibits/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.This_Exhibit = repo.GetExhibitById(id);
            return View();
        }

        public ActionResult Add_Exhibit(Exhibit exhibit)
        {
            if (ModelState.IsValid)
            {
                repo.AddNewExhibit(exhibit);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
