using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.ViewModels
{
    public class StoryViewModal
    {
        public int Id { get; set; }
        [Required]
        public string Storie { get; set; }
     
    }
}
