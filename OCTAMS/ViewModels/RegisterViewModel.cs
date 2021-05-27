using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Mobile no not valid")]
        public string Phone { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string CPassword { get; set; }
        [Required]
        public bool isDoctor { get; set; }
        public bool RemamberMe { get; set; }
        
    }
}
