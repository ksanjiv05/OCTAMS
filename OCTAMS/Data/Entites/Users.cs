using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Entites
{
    public class Users:IdentityUser
    {
        public string Name { get; set; }
        public bool IsDoctor { get; set; }        
    }
}
