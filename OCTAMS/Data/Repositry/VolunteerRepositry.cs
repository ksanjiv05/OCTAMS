using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public class VolunteerRepositry : IVolunteerRepositry
    {
        private readonly DBContext _context;

        public VolunteerRepositry(DBContext context)
        {
            _context = context;
        }
        public bool AddVolunteer(Volunteer newVolunteer)
        {
            try
            {
                _context.Volunteers.Add(newVolunteer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteVolunteer(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Volunteer> getVolunteers(string uid)
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

        public IEnumerable<Volunteer> getVolunteers()
        {
            try
            {
               return _context.Volunteers.ToList();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public bool UpdateVolunteer(Volunteer newVolunteer)
        {
            throw new NotImplementedException();
        }

        public Volunteer Volunteer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
