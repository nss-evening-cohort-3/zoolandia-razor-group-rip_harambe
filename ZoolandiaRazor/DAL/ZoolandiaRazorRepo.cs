using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.DAL
{
    public class ZoolandiaRazorRepo
    {
        public ZoolandiaRazorContext Context { get; set; }
        public ZoolandiaRazorRepo()
        {
            Context = new ZoolandiaRazorContext();
        }

        public ZoolandiaRazorRepo(ZoolandiaRazorContext _context)
        {
            Context = _context;
        }

        public List<Animals> GetAllAnimals()
        {
            return Context.Animals.ToList();
        }
        
        //public void AddNewAnimal(string Name, int Age, Exhibit Exhibit, Species Species)
        //{
        //    Animals animal = new Animals {Name=Name, Age=Age, Exhibit=Exhibit, Species=Species };
        //    Context.Animals.Add(animal);
        //    Context.SaveChanges();
        //}
        public void AddNewAnimal(Animals my_animal)
        {
            Context.Animals.Add(my_animal);
            Context.SaveChanges();
        }
        public void AddNewAnimal(string name, int age)
        {
            Animals animal = new Models.Animals { Name = name, Age = age };
            Context.Animals.Add(animal);
            Context.SaveChanges();
        }
        public Animals FindAnimalByName(string animal_name)
        {
            Animals found_animal = Context.Animals.FirstOrDefault(a => a.Name.ToLower() == animal_name.ToLower());
            return found_animal;
        }

        public Animals RemoveAnimal(string my_animal)
        {
            Animals animal_to_remove = FindAnimalByName(my_animal);
            if (animal_to_remove != null)
            {
                Context.Animals.Remove(animal_to_remove);
                Context.SaveChanges();
            }
            return animal_to_remove;
        }

    }
}