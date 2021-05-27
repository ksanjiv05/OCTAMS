using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Models
{
    public class Articles
    {
        public int Id { get; set; }
        [Required]
        public string Article { get; set; }
        [Required]
        public string Title { get; set; }
        
        public string Uid { get; set; }

    }
}
