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
        [Required]
        public Exhibit Exhibit { get; set; }
        [Required]
        public Species Species { get; set; }
    }
}