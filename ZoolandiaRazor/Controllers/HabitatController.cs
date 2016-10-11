using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class HabitatController : Controller
    {
        ZoolandiaRazorRepo repo = new ZoolandiaRazorRepo();

        // GET: Habitat
        public ActionResult Index()
        {
            ViewBag.All_Habitats = repo.GetAllHabitats();
            return View();
        }

        // GET: Habitat/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.This_Habitat = repo.FindHabitatById(id);
            return View();
        }

    }
}
