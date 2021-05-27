using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Models
{
    public class Questions
    {
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        public string Uid { get; set; }
        public string Answer { get; set; } = "";
    }
}
