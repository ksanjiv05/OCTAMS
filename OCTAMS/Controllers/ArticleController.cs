using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OCTAMS.Data.Entites;
using OCTAMS.Data.Repositry;
using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepositry _repositry;
        private readonly UserManager<Users> _manager;

        public ArticleController(IArticleRepositry repositry, UserManager<Users> manager)
        {
            _repositry = repositry;
            _manager = manager;
        }
        [HttpGet]
        public IActionResult Article()
        {
            try
            {
                ViewBag.ArticleData = _repositry.getArticles();
            }
            catch (Exception ex)
            {
                Console.WriteLine("--" + ex);
                ViewBag.ArticleData = null;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Article(Articles model)
        {

            if (ModelState.IsValid)
            {
                var user = await _manager.GetUserAsync(User);
                Console.WriteLine("userr" + user.Name + " id" + user.UserName);

                bool status = _repositry.AddArticle(new  Articles()
                {
                    Title=model.Title,
                    Article = model.Article,
                    Uid = user.UserName,
                    
                });
                Console.WriteLine("status - " + status.ToString());
                ViewData["status"] = status;
            }
            ViewBag.ArticleData = _repositry.getArticles();
            Console.WriteLine("daa"+model.Article);
            return View();
        }

        public IActionResult Delete(string ID)
        {
            Console.WriteLine("id - " + ID);
            try
            {
                _repositry.DeleteArticle(Int32.Parse(ID));
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction("Article");
        }
    }
}
