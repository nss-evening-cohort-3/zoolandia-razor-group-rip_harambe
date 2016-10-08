using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{
    public class HabitatType
    {
        [Key]
        public int HabitatTypeId { get; set; }
        [Required]
        public string Habitat { get; set; }

    }
}