using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public interface IVolunteerRepositry
    {
        public bool DeleteVolunteer(int id);
        public bool AddVolunteer(Volunteer newVolunteer);
        public bool UpdateVolunteer(Volunteer newVolunteer);
        public Volunteer Volunteer(int id);
        public IEnumerable<Volunteer> getVolunteers(string uid);
        public IEnumerable<Volunteer> getVolunteers();
    }
}
