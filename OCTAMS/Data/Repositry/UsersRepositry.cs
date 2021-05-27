using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public class UsersRepositry:IUsersRepositry
    {
        private readonly DBContext _context;

        public UsersRepositry(DBContext context)
        {
            _context = context;
        }
        public bool SaveAll()
        {
           return _context.SaveChanges()>0;   
        }
        
        public void AddUser(Register newUser)
        {
            try
            {
                _context.Register.Add(newUser);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public IEnumerable<Register> GetUsers()
        {
            try
            {
               return _context.Register.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public IEnumerable<Register> GetUsers(string uid)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
