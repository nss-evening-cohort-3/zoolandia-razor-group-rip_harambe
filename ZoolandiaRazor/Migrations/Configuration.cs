    namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZoolandiaRazor.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZoolandiaRazor.DAL.ZoolandiaRazorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZoolandiaRazor.DAL.ZoolandiaRazorContext context)
        {
            //  This method will be called after migrating to the latest version.

            Exhibit exhibit1 = new Exhibit() { Exhibit_Name = "FunkyTown", Habitat_Type = "Grassy Noll" };
            Exhibit exhibit2 = new Exhibit() { Exhibit_Name = "McDonald's", Habitat_Type = "Greasy" };
            List<Exhibit> exhibitTest = new List<Exhibit>();
            exhibitTest.Add(exhibit1);
            exhibitTest.Add(exhibit2);
            context.Employee.AddOrUpdate(
                e => e.LastName,
                new Employee { FirstName = "Tim", LastName = "Maddux", Age = 30, Exhibits = exhibitTest }
                //new Employee { LastName = "Ventura" },
                //new Employee { LastName = "Cramb" }
                );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
