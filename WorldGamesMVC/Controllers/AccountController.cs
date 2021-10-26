using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldGamesMVC.ViewModels;

namespace WorldGamesMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager,
                                             SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
            _signInManager = signManager;
        }
       
        [HttpGet]
        public IActionResult Login (string returnUrl)
        {
            return View(new LoginVM
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginVM loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }
            var user = await _userManager.FindByNameAsync(loginVm.UserName);
            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user,
                    loginVm.Password, false, false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVm.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction(loginVm.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Usuário ou Senha inválidos ou não localizados");
            return View(loginVm);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginVM registerVm)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = registerVm.UserName };
                var result = await _userManager.CreateAsync(user, registerVm.Password);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Usuário ou Senha inválidos ou não localizados");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View(registerVm);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
