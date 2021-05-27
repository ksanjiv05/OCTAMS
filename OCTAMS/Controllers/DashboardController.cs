using Microsoft.AspNetCore.Mvc;
using OCTAMS.Data.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IStoryRepositry _repositry;
        private readonly IArticleRepositry _articles;
        private readonly IQuestionRepositry _questions;
      

        public DashboardController(IStoryRepositry repositry, IArticleRepositry articles, IQuestionRepositry questions)
        {
            _repositry = repositry;
            _articles = articles;
            _questions = questions;
          
        }
        public IActionResult Index()
        {
            try
            {
               if(User.Identity.IsAuthenticated)
                {
                    string uid = User.Identity.Name; 
                    ViewBag.UserStories = _repositry.getStories(uid);
                    ViewBag.UserArticles = _articles.getArticles(uid);
                    ViewBag.UserQuestions = _questions.getQuestions(uid);
                    
                }
                else
                {
                    return RedirectToAction("Login","Auth");
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }
    }
}

