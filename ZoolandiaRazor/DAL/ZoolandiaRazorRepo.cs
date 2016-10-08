using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}