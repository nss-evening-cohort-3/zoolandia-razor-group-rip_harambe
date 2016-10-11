using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.Controllers
{
    public class AnimalController : Controller
    {
        ZoolandiaRazorRepo repo = new ZoolandiaRazorRepo();

        // GET: Animal
        public ActionResult Index()
        {
            ViewBag.All_Animals = repo.GetAllAnimals();
            return View();
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.This_Animal = repo.FindAnimalById(id);
            return View();
        }

        [HttpPost]
        public ActionResult Add_Animal(Animals animal)
        {
            if (ModelState.IsValid)
            {
                repo.AddNewAnimal(animal);
                return RedirectToAction("Index");
            }

            return View(animal);
        }
    }
}
