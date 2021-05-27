using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Data.Repositry
{
    public class StoryRepositry : IStoryRepositry
    {
        private readonly DBContext _context;

        public StoryRepositry(DBContext context)
        {
            _context = context;
        }
        public bool AddStory(Story newStory)
        {
            try
            {
                _context.Story.Add(newStory);
                _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
           
        }

        public bool UpdateStory(Story newStory)
        {
            try
            {
                Story story= _context.Story.FirstOrDefault(st => st.Id == newStory.Id);
               
                if (story!= null)
                {
                    Console.WriteLine("story " + story.Storie);
                    story.Storie = newStory.Storie;
                    _context.SaveChanges();
                }
               
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public bool DeleteStory(int Id)
        {
            try
            {
                Story story = _context.Story.FirstOrDefault(st => st.Id ==Id);
                Console.WriteLine(story != null);
                if (story!= null)
                {
                    _context.Story.Remove(story);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public IEnumerable<Story> getStories(string uid)
        {
            try
            {

              return  _context.Story.Where(st => st.Uid == uid).ToList();

            }catch(Exception ex)
            {
                Console.WriteLine("err" + ex);
                return null;
            }
        }
        public IEnumerable<Story> getStories()
        {
            try
            {

                return _context.Story.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine("err" + ex);
                return null;
            }
        }

        public Story getStory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
