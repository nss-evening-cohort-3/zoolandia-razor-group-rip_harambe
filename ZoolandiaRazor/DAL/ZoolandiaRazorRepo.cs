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
        public List<Employee> GetAllEmployees()
        {
            return Context.Employee.ToList();
        }

        internal dynamic GetExhibitById(int habitat_id)
        {
            HabitatType found_habitat = Context.Habitat.FirstOrDefault(a => a.HabitatTypeId == habitat_id);
            return found_habitat;
        }

        public List<HabitatType> GetAllHabitats()
        {
            return Context.Habitat.ToList();
        }
        public List<Species> GetAllSpecies()
        {
            return Context.Species.ToList();
        }
        public List<Exhibit> GetAllExhibits()
        {
            return Context.Exhibit.ToList();
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
        public Animals FindAnimalById(int animal_id)
        {
            Animals found_animal = Context.Animals.FirstOrDefault(a => a.AnimalId == animal_id);
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


        public void AddNewEmployee(Employee my_employee)
        {
            Context.Employee.Add(my_employee);
            Context.SaveChanges();
        }
        public Employee FindEmployeeByFirstName(string firstname)
        {
            Employee found_employee = Context.Employee.FirstOrDefault(e => e.FirstName.ToLower() == firstname.ToLower());
            return found_employee;
        }
        public Employee FindEmployeeByLastName(string lastname)
        {
            Employee found_employee = Context.Employee.FirstOrDefault(e => e.LastName.ToLower() == lastname.ToLower());
            return found_employee;
        }
        public Employee RemoveEmployeeByLastName(string lastName)
        {
            Employee employee_to_remove = FindEmployeeByLastName(lastName);
            if (employee_to_remove != null)
            {
                Context.Employee.Remove(employee_to_remove);
                Context.SaveChanges();
            }
            return employee_to_remove;
        }
        public Employee RemoveEmployeeByFirstName(string firstName)
        {
            Employee employee_to_remove = FindEmployeeByFirstName(firstName);
            if(employee_to_remove !=null)
            {
                Context.Employee.Remove(employee_to_remove);
                Context.SaveChanges();
            }
            return employee_to_remove;
        }

        public void AddNewHabitat(HabitatType habitat)
        {
            Context.Habitat.Add(habitat);
            Context.SaveChanges();
        }
        public HabitatType FindHabitatByName(string habitatName)
        {
            HabitatType found_habitat = Context.Habitat.FirstOrDefault(e => e.Habitat.ToLower() == habitatName.ToLower());
            return found_habitat;
        }

        public HabitatType FindHabitatById(int habitat_id)//
        {
            HabitatType found_habitat = Context.Habitat.FirstOrDefault(a => a.HabitatTypeId == habitat_id);
            return found_habitat;
        }

        public HabitatType RemoveHabitatByType(string habitatType)
        {
            HabitatType habitat_to_remove = FindHabitatByName(habitatType);
            if (habitatType != null)
            {
                Context.Habitat.Remove(habitat_to_remove);
                Context.SaveChanges();
            }
            return habitat_to_remove;
        }

        public void AddNewSpecies(Species species)
        {
            Context.Species.Add(species);
            Context.SaveChanges();
        }
        public Species FindSpeciesByCommonName(string commonName)
        {
            Species found_species = Context.Species.FirstOrDefault(e => e.Common_Name.ToLower() == commonName.ToLower());
            return found_species;
        }
        public Species RemoveSpeciesByCommonName(string commonName)
        {
            Species species_to_remove = FindSpeciesByCommonName(commonName);
            if (commonName != null)
            {
                Context.Species.Remove(species_to_remove);
                Context.SaveChanges();
            }
            return species_to_remove;
        }
        public void AddNewExhibit(Exhibit exhibit)
        {
            Context.Exhibit.Add(exhibit);
            Context.SaveChanges();
        }

        public Exhibit FindExhibitByName(string exhibitName)
        {
            Exhibit found_exhibit = Context.Exhibit.FirstOrDefault(e => e.Exhibit_Name.ToLower() == exhibitName.ToLower());
            return found_exhibit;
        }
        public Exhibit RemoveExhibitByName(string exhibitName)
        {
            Exhibit exhibit_to_remove = FindExhibitByName(exhibitName);
            if (exhibitName != null)
            {
                Context.Exhibit.Remove(exhibit_to_remove);
                Context.SaveChanges();
            }
            return exhibit_to_remove;
        }
    }
}