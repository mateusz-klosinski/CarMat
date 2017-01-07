using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarMat.Models;
using Microsoft.EntityFrameworkCore;
using CarMat.ViewModels;
using CarMat.Repositories;

namespace CarMat.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var username = User.Identity.Name;

            var offersWithVehicles = _unitOfWork.Offers.GetFutureOffers(username);

            return View(offersWithVehicles);
        }


        public IActionResult Search(string query)
        {
            var username = User.Identity.Name;

            if (!string.IsNullOrWhiteSpace(query))
            {
                var offers = _unitOfWork.Offers.GetFutureOffersThatContainsQuery(username, query);
                return View(offers);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
