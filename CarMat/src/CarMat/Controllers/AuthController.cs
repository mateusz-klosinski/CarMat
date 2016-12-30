using CarMat.Models;
using CarMat.Services;
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
        private IAuthService _service;


        public AuthController(IAuthService service)
        {
            _service = service;
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
                var isLoggedIn = await _service.SignInUserAsync(viewModel.UserName, viewModel.Password);

                if (isLoggedIn)
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
                await _service.SignOutUserAsync();
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
                var creationResult = await _service.CreateUserAsync(viewModel);

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
