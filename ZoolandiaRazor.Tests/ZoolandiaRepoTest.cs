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

        public void ConnectMocksToDatastore()
        {
            var queryable_animal_list = animal_list.AsQueryable();
            mock_animal_table.As<IQueryable<Animals>>().Setup(m => m.Provider).Returns(queryable_animal_list.Provider);
            mock_animal_table.As<IQueryable<Animals>>().Setup(m => m.Expression).Returns(queryable_animal_list.Expression);
            mock_animal_table.As<IQueryable<Animals>>().Setup(m => m.ElementType).Returns(queryable_animal_list.ElementType);
            mock_animal_table.As<IQueryable<Animals>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_animal_list.GetEnumerator());

            mock_context.Setup(c => c.Animals).Returns(mock_animal_table.Object);
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
            Animals my_animal = new Animals { Name = "Bob", Age = 35, Exhibit = null, Species = null };
            repo.AddNewAnimal(my_animal);
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

        }
    }
}
