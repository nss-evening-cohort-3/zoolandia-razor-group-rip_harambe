using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{
    public class Animals
    {
        [Key]
        public int AnimalId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public virtual Exhibit Exhibit { get; set; }
        public virtual Species Species { get; set; }
    }
}