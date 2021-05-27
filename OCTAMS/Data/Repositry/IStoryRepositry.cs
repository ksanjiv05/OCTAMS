using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public interface IStoryRepositry
    {
        public bool AddStory(Story newStory);
        public bool UpdateStory(Story newStory);
        public bool DeleteStory(int Id);
        public Story getStory(int id);
        public IEnumerable<Story> getStories(string uid);
        public IEnumerable<Story> getStories();
    }
}
