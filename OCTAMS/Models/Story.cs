using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Models
{
    public class Story
    {
        public int Id { get; set; }
        [Required]
        public string Storie { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Uid { get; set; }

    }
}
