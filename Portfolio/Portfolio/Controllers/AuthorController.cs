using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModel.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class AuthorController : Controller
    {
        private UserManager<AppUser> _manager { get; }
        private SignInManager<AppUser> _signIn { get; }
        public AuthorController(UserManager<AppUser> manager, SignInManager<AppUser> signIn)
        {
            _manager = manager;
            _signIn = signIn;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            AppUser user = new AppUser
            {
                Name = registerVM.FirstName,
                Surname = registerVM.LastName,
                UserName = registerVM.UserName,
                Email = registerVM.Email
            };
            IdentityResult result = await _manager.CreateAsync(user, registerVM.Password);
            if (!ModelState.IsValid) return View();
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            await _signIn.SignInAsync(user, true);
            return RedirectToAction("Index", "Home");
        }
    }
}
