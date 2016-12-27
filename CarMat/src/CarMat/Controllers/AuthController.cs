using CarMat.Models;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers
{
    public class AuthController : Controller
    {
        private CMContext _context;
        private SignInManager<CMUser> _manager;
        private UserManager<CMUser> _userManager;

        public AuthController(SignInManager<CMUser> manager, UserManager<CMUser> userManager, CMContext context)
        {
            _manager = manager;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string redirectUrl)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _manager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, true, false);

                if (loginResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(redirectUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(redirectUrl);
                    }

                }
            }

            ModelState.AddModelError("", "Niepoprawna nazwa użytkownika lub hasło");
            return View(viewModel);
        }


        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _manager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userDemographics = _context.Demographics
                    .Where(d => d.City.Equals(viewModel.City, StringComparison.CurrentCultureIgnoreCase) &&
                    d.Province.Name.Equals(viewModel.Province, StringComparison.CurrentCultureIgnoreCase))
                    .FirstOrDefault();

                if (userDemographics == null)
                {
                    var userProvince = _context.Provinces
                        .Where(p => p.Name
                        .Equals(viewModel.Province, StringComparison.CurrentCultureIgnoreCase))
                        .FirstOrDefault();

                    userDemographics = new Demographics
                    {
                        City = viewModel.City,
                        Province = userProvince
                    };
                }

                var newUser = new CMUser
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Demographics = userDemographics
                };

                var creationResult = await _userManager.CreateAsync(newUser, viewModel.Password);

                if (creationResult.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in creationResult.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            return View(viewModel);
        }

    }
}
