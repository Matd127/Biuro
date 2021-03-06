using Biuro_Podrozy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager; 
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) 
        { 
            _userManager = userManager;
            _signInManager = signInManager; 
        }

        [AllowAnonymous] 
        [HttpGet]
        public IActionResult Login(string returnUrl)
        { 
            return View(new LoginModel 
            { 
                ReturnUrl = returnUrl 
            }); 
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        { 
            if (ModelState.IsValid)
            { 
                IdentityUser user = await _userManager.FindByNameAsync(loginModel.Name); 
                if (user != null) 
                {                  
                    await _signInManager.SignOutAsync(); 
                    if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Biuro/Panel");
                    } 
                } 
            } 
            ModelState.AddModelError(string.Empty, "Nieprawidłowa nazwa użytkownika lub hasło"); 
            return View(loginModel); 
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/") 
        { 
            await _signInManager.SignOutAsync(); 
            return Redirect(returnUrl); 
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
