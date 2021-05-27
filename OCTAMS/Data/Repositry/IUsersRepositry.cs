using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public interface IUsersRepositry
    {
       public void AddUser(Register newUser);
       public IEnumerable<Register> GetUsers();
        public IEnumerable<Register> GetUsers(string uid);
    }
}
