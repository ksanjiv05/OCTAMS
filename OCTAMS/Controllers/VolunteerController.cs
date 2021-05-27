using Microsoft.AspNetCore.Mvc;
using OCTAMS.Data.Repositry;
using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IVolunteerRepositry _repositry;

        public VolunteerController(IVolunteerRepositry repositry)
        {
            _repositry = repositry;
        }
        [HttpGet]
        public IActionResult Volunteer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Volunteer(Volunteer model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   var status= _repositry.AddVolunteer(model);
                    if (status)
                    {
                        ViewBag.status = "success";
                    }
                    else
                    {
                        ViewBag.status = "error";
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    ViewBag.status = "error";
                }
            }
            
            return View();
        }
    }
}
