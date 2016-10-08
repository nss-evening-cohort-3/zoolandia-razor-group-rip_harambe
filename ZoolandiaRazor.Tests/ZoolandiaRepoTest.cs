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
        [TestMethod]
        public void EnsureCanCreateInstanceOfModelClasses()
        {
            Animals Animals = new Animals();
            Employee Employees = new Employee();
            HabitatType HabitatTypes = new HabitatType();
            Exhibit Exhibits = new Exhibit();
            Species Species = new Species();
            ZoolandiaRazorRepo Repo = new ZoolandiaRazorRepo();
            Assert.IsNotNull(Animals);
            Assert.IsNotNull(Employees);
            Assert.IsNotNull(HabitatTypes);
            Assert.IsNotNull(Exhibits);
            Assert.IsNotNull(Species);
            Assert.IsNotNull(Repo);
        }
    }
}
