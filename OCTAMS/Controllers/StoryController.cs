using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OCTAMS.Data.Entites;
using OCTAMS.Data.Repositry;
using OCTAMS.Models;
using OCTAMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Controllers
{
    //[Route("api/[controller]")]
    public class StoryController : Controller
    {
        private readonly IStoryRepositry _repositry;
        private readonly UserManager<Users> _manager;

        public StoryController(IStoryRepositry repositry,UserManager<Users> manager)
        {
            _repositry = repositry;
            _manager = manager;
        }
        [HttpGet]
        public IActionResult Story()
        {
            try
            {
                ViewBag.StoryData = _repositry.getStories();
            }
            catch(Exception ex)
            {
                Console.WriteLine("--" + ex);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Story(StoryViewModal model)
        {
            
            Console.WriteLine("story" + model.Storie);
           
            if (ModelState.IsValid)
            {
                var user = await _manager.GetUserAsync(User);
                Console.WriteLine("userr" + user.Name + " id" + user.UserName);

                bool status=  _repositry.AddStory(new Story()
                {
                    Storie=model.Storie,
                    Uid=user.UserName,
                    Author=user.Name
                });
                Console.WriteLine("status - "+status.ToString());
            }
            ViewBag.StoryData = _repositry.getStories();
            return View();
        }

        public IActionResult UpdateStory(Story story)
        {
            Console.WriteLine(story.Id+"id--" +story.Storie);
            try
            {
                _repositry.UpdateStory(story);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction("Story");
        }
        public IActionResult Delete(string ID)
        {
            try
            {
                _repositry.DeleteStory(Int32.Parse( ID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction("Story");
        }
        [HttpGet]
        public ActionResult<IEnumerable<Story>> Get(String uid)
        {
            try
            {
                return Ok( _repositry.getStories(uid));

            }
            catch (Exception ex)
            {
              return   BadRequest("Not found");
            }

        }
    }
}
