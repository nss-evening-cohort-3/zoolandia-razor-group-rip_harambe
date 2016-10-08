using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{
    public class Exhibit
    {
        [Key]
        public int ExhibitId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Habitat_Type { get; set; }

    }
}