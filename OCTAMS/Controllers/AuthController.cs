using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OCTAMS.Data.Entites;
using OCTAMS.Data.Repositry;
using OCTAMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCTAMS.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsersRepositry _repositry;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;

        public AuthController(IUsersRepositry repositry, SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            _repositry = repositry;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel modal )
        {
            Console.WriteLine("username---"+modal.isDoctor);
            Console.WriteLine(modal);

            if (ModelState.IsValid)
            {
                Console.WriteLine("username", modal.Name.Length);
                Console.WriteLine(modal);
              


                var user = new Users { UserName = modal.Email,Email=modal.Email,Name = modal.Name,PhoneNumber= modal.Phone,IsDoctor=modal.isDoctor };
                var result = await _userManager.CreateAsync(user, modal.Password);
                
                if (result.Succeeded)
                {
                    ViewBag.UserName = modal.Email;
                    await _signInManager.SignInAsync(user, false);
                    
                    _repositry.AddUser(new Models.Register()
                    {
                        Name = modal.Name,
                        Email = modal.Email,
                        Password = modal.Password,
                        Phone = modal.Phone,
                        IsDoctor = modal.isDoctor,
                        Uid= modal.Email
                    });
                   
                    Console.WriteLine(modal.Email,"success login");
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    Console.WriteLine("failed login" );
                    ModelState.AddModelError("", "Invalid UserName or Password !");
                }


            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    
                    Console.WriteLine("successs ful login");
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    Console.WriteLine("failed ful login");
                    ModelState.AddModelError("", "Invalid login attempt");
                }
            }
            
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}
