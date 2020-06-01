using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MojKomisEMPTY.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MojKomisEMPTY.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvn)
        {
            if(!ModelState.IsValid)
                return View(loginvn);

            var user =await _userManager.FindByNameAsync(loginvn.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginvn.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Nazwa użytkownika/haslo nie jest własciwe");
            return View(loginvn);
        }

        public IActionResult Register()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task< IActionResult> Register(LoginVM loginvn)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = loginvn.UserName };
                var result = await _userManager.CreateAsync(user, loginvn.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginvn);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
