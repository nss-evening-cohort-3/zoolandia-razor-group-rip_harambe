using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZoolandiaRazor.Tests
{
    [TestClass]
    public class ZoolandiaRepoTest
    {
        Mock<ZoolandiaRazorContext> mock_context { get; set; }
        Mock<DbSet<Animals>> mock_animal_table { get; set; }
        List<Animals> animal_list { get; set; }
        ZoolandiaRazorRepo repo { get; set; }
        Animals my_animal1 = new Animals { AnimalId = 0, Name = "Bob", Age = 30, Exhibit = null, Species = null };
        Animals my_animal2 = new Animals { AnimalId = 1, Name = "George", Age = 20, Exhibit = null, Species = null };
        Animals my_animal3 = new Animals { AnimalId = 2, Name = "Vincent", Age = 15, Exhibit = null, Species = null };

        public void ConnectMocksToDatastore()
        {
            var queryable_animal_list = animal_list.AsQueryable();
            mock_animal_table.As<IQueryable<Animals>>().Setup(m => m.Provider).Returns(queryable_animal_list.Provider);
            mock_animal_table.As<IQueryable<Animals>>().Setup(m => m.Expression).Returns(queryable_animal_list.Expression);
            mock_animal_table.As<IQueryable<Animals>>().Setup(m => m.ElementType).Returns(queryable_animal_list.ElementType);
            mock_animal_table.As<IQueryable<Animals>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_animal_list.GetEnumerator());

            mock_context.Setup(c => c.Animals).Returns(mock_animal_table.Object);
            mock_animal_table.Setup(t => t.Add(It.IsAny<Animals>())).Callback((Animals a) => animal_list.Add(a));
            mock_animal_table.Setup(t => t.Remove(It.IsAny<Animals>())).Callback((Animals a) => animal_list.Remove(a));
            mock_animal_table.Setup(t => t.Add(It.IsAny<Animals>())).Callback((Animals a) => animal_list.Add(a));


        }
        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ZoolandiaRazorContext>();
            mock_animal_table = new Mock<DbSet<Animals>>();
            animal_list = new List<Animals>();
            repo = new ZoolandiaRazorRepo(mock_context.Object);

            ConnectMocksToDatastore();


        }
        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void EnsureCanCreateInstanceOfModelClasses()
        {
            ZoolandiaRazorRepo Repo = new ZoolandiaRazorRepo();
            Assert.IsNotNull(Repo);
        }
        [TestMethod]
        public void EnsureCanCreateInstanceWithMockInitialized()
        {
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void EnsureRepoHasContext()
        {
            ZoolandiaRazorContext actual_context = repo.Context;
            Assert.IsInstanceOfType(actual_context, typeof(ZoolandiaRazorContext));
        }
        [TestMethod]
        public void EnsureAnimalDatabaseIsEmpty()
        {
            List<Animals> all_animals = repo.GetAllAnimals();
            int expected_animal_count = 0;
            int actual_animal_count = all_animals.Count();
            Assert.AreEqual(expected_animal_count, actual_animal_count);
        }
        [TestMethod]
        public void EnsureCanAddAnimalToDatabase()
        {
            repo.AddNewAnimal(my_animal1);
            List<Animals> all_animals = repo.GetAllAnimals();
            int expected_animal_count = 1;
            int actual_animal_count = all_animals.Count();
            Assert.AreEqual(expected_animal_count, actual_animal_count);
        }
        [TestMethod]
        public void EnsureCanAddAnimalWithDifferentArgumentstoDatabase()
        {
            repo.AddNewAnimal("Steve", 20);
            List<Animals> all_animals = repo.GetAllAnimals();
            int expected_count = 1;
            int actual_count = all_animals.Count();
            Assert.AreEqual(expected_count, actual_count);
        }
        [TestMethod]
        public void EnsureCanAddMultipleAnimalsToDatabase()
        {
            repo.AddNewAnimal(my_animal1);
            repo.AddNewAnimal(my_animal2);
            repo.AddNewAnimal(my_animal3);
            List<Animals> all_animals = repo.GetAllAnimals();
            int expected_count = 3;
            int actual_count = all_animals.Count();
            Assert.AreEqual(expected_count, actual_count);
        }
        [TestMethod]
        public void EnsureCanLocateAnimalByName()
        {
            repo.AddNewAnimal(my_animal1);
            repo.AddNewAnimal(my_animal2);
            repo.AddNewAnimal(my_animal3);
            string animal_name = "bob";
            int expected_animal_id = 0;
            Animals actual_animal = repo.FindAnimalByName(animal_name);
            int actual_animal_id = actual_animal.AnimalId;
            Assert.AreEqual(expected_animal_id, actual_animal_id);

        }
        [TestMethod]
        public void EnsureCanRemoveAnimalFromDatabase()
        {
            repo.AddNewAnimal(my_animal1);
            Assert.IsTrue(repo.GetAllAnimals().Count() == 1);
            repo.RemoveAnimal("Bob");
            Assert.IsTrue(repo.GetAllAnimals().Count() == 0);
        }
        [TestMethod]
        public void EnsureCanRemoveMultipleAnimalsFromDatabase()
        {
            repo.AddNewAnimal(my_animal1);
            repo.AddNewAnimal(my_animal2);
            repo.AddNewAnimal(my_animal3);
            Assert.IsTrue(repo.GetAllAnimals().Count() == 3);
            repo.RemoveAnimal("George");
            repo.RemoveAnimal("Vincent");
            Assert.IsTrue(repo.GetAllAnimals().Count() == 1);
        }
        [TestMethod]
        public void EnsureCanAddEmployees()
        {

        }
        [TestMethod]
        public void EnsureCanFindEmployeesByName()
        {

        }
        [TestMethod]
        public void EnsureCanDeleteEmployeesByName()
        {

        }
        [TestMethod]
        public void EnsureCanAddHabitats()
        {

        }
        [TestMethod]
        public void EnsureCanFindHabitatsByName()
        {

        }
        [TestMethod]
        public void EnsureCanDeleteHabitatsByName()
        {

        }
        [TestMethod]
        public void EnsureCanAddSpecies()
        {

        }
        [TestMethod]
        public void EnsureCanFindSpeciesByCommonName()
        {

        }
        [TestMethod]
        public void EnsureCanDeleteSpeciesByCommonName()
        {

        }
    }
}
