using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }
        [Required]
        public string Scientific_Name { get; set; }
        [Required]
        public string Common_Name { get; set; }
        public virtual HabitatType Habitat { get; set; }
        
    }
}