using Microsoft.AspNetCore.Mvc;
using OCTAMS.Data.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IStoryRepositry _repositry;
        private readonly IArticleRepositry _articles;
        private readonly IQuestionRepositry _questions;
        private readonly IUsersRepositry _users;
        private readonly IVolunteerRepositry _volunteer;

        public ReportsController(IStoryRepositry repositry, IArticleRepositry articles, IQuestionRepositry questions, IUsersRepositry users,IVolunteerRepositry volunteer)
        {
            _repositry = repositry;
            _articles = articles;
            _questions = questions;
            _users = users;
            _volunteer = volunteer;
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.Stories = _repositry.getStories();
                ViewBag.Articles = _articles.getArticles();
                ViewBag.Questions = _questions.getQuestions();
                ViewBag.Users = _users.GetUsers();
                ViewBag.Volunteers = _volunteer.getVolunteers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }
    }
}
