﻿using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    //hesap denetleyicisi
    public class AccountController : Controller
    {
        private readonly AspNetUserManager<IdentityUser> userManager;

        public AccountController(AspNetUserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
            };
            
            var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);

            if (identityResult.Succeeded)
            {
               var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");

                if(roleIdentityResult.Succeeded)
                {
                    return RedirectToAction("Register");
                }
            }
            return View();
        }
    }
}
