using System.Data.Entity;
using ZoolandiaRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.DAL
{
    public class ZoolandiaRazorContext : DbContext
    {
        public virtual DbSet<Animals> Animals { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<HabitatType> Habitat { get; set; }
        public virtual DbSet<Exhibit> Exhibit { get; set; }

    }
}