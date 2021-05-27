using Microsoft.AspNetCore.Mvc;
using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Controllers
{
    public class AssesmentController : Controller
    {
        [HttpGet]
        public IActionResult Assesment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Assesment(Assesment assesment)
        {
           
            bool[] assest = { 
                assesment.Q1,
                assesment.Q2,
                assesment.Q3,
                assesment.Fever,
                assesment.Cough,
                assesment.Sorethroat,
                assesment.Shortnessofbreath,
                assesment.Difficultybreathing,
                assesment.Chills,
                assesment.Musclepain,
                assesment.Headache,
                assesment.GIsymptoms,
                assesment.Losstasteorsmell
            };
            int count = 0;
            for(int i=0; i<assest.Length; i++)
            {
                Console.WriteLine(assest[i]);
                if (assest[i])
                {
                    count++;
                }
            }

            if (count > 5)
            {
                Console.WriteLine("You are at high risk plesae contact doctor and isolate");
            }
            else
            {
                Console.WriteLine("isolate you are low risk");
            }
            return View();
        }
    }
}
