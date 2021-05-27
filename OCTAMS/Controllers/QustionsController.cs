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
    public class QustionsController : Controller
    {
        private readonly IQuestionRepositry _repositry;
        private readonly UserManager<Users> _manager;

        public QustionsController(IQuestionRepositry repositry, UserManager<Users> manager)
        {
            _repositry = repositry;
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> Qustions()
        {
            try
            {
                ViewBag.QuestionData = _repositry.getQuestions();
                var user = await _manager.GetUserAsync(User);
                ViewBag.IsDoctor = user.IsDoctor;
                // _manager.GetUserAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("--" + ex);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Qustions(Questions model)
        {
            var user = await _manager.GetUserAsync(User);
            Console.WriteLine("qus  " + model.Answer + "--" + model.Uid+" uu  "+model.Question);
            if (ModelState.IsValid)
            {


                Console.WriteLine("userr" + user.Name + " id" + user.UserName);

                bool status = _repositry.AddQuestion(new Questions()
                {
                    Question = model.Question,
                    Uid = user.UserName,
                    Answer = ""
                });
                Console.WriteLine("status - " + status.ToString());
                Console.WriteLine("qus" + model.Answer+"--"+model.Uid);
            }
            ViewBag.QuestionData = _repositry.getQuestions();
            ViewBag.IsDoctor = user.IsDoctor;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Answer(Questions model)
        {
            var user = await _manager.GetUserAsync(User);
            _repositry.UpdateAnswer(model);
            Console.WriteLine("qus is -- " + model.Answer + "--" + model.Uid + " uu  " + model.Id);
            return RedirectToAction("Qustions");
        }
        
    }
}
