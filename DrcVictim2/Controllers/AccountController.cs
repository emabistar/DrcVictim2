using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrcVictim2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VictimData.Models;
using VictimData.Static;

namespace DrcVictim2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login() =>  View( new LoginVM());
        
        [HttpPost]
        public async Task<IActionResult>Login(LoginVM loginvm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginvm);
            }
            var user = await _userManager.FindByEmailAsync(loginvm.EmailAddress);

            if(user != null)
            {
                // Check Pass if correct
                var passwordCheck = await _userManager.CheckPasswordAsync(user,loginvm.Password);

                if (passwordCheck)
                {

                    var result = await _signInManager.PasswordSignInAsync(user, loginvm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Create", "Data");
                    }

                }

               
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginvm);
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginvm);
        }

        [HttpGet]
        public IActionResult Register() => View(new RegisterVM());


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVm);
            }
            var user = await _userManager.FindByEmailAsync(registerVm.EmailAddress);
            if(user != null)
            {
                TempData["Error"] = "This email address is already is use";
                return View(registerVm);
            }
            var newUser = new ApplicationUser
            {
                FullName = registerVm.FullName,
                Email = registerVm.EmailAddress,
                UserName = registerVm.EmailAddress,
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVm.Password);
            if (!newUserResponse.Succeeded)
            {
                TempData["Error"] =  null;

                foreach(var error in newUserResponse.Errors)
                {
                    TempData["Error"]= error.Description;
                }

                return View(registerVm);
            }

          
            await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            return View("RegisterCompleted");


            


        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Create", "Data");
        }
        [HttpGet]
        
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

    }
}
