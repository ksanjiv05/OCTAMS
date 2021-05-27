﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Models
{
    public class Register
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Uid { get; set; }
        [Required]
        public bool IsDoctor { get; set; }
        public bool RemamberMe { get; set; }
        
    }
}
