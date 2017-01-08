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

            var model = new OffersWithFiltersViewModel
            {
                Offers = offersWithVehicles,
                Filters = new Filters(),
            };

            return View(model);
        }


        public IActionResult Search(string query)
        {
            var username = User.Identity.Name;

            if (!string.IsNullOrWhiteSpace(query))
            {
                var offers = _unitOfWork.Offers.GetFutureOffersThatContainsQuery(username, query);

                var model = new OffersWithFiltersViewModel
                {
                    Offers = offers,
                    Filters = new Filters(),
                };

                return View(model);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Filter(OffersWithFiltersViewModel model, string query = null)
        {
            var username = User.Identity.Name;
            List<SimpleOfferViewModel> offers;

            if (!string.IsNullOrWhiteSpace(query))
            {
                offers = _unitOfWork.Offers.GetFutureOffersThatContainsQuery(username, query);
            }
            else
            {
                offers = _unitOfWork.Offers.GetFutureOffers(username);
            }

            List<SimpleOfferViewModel> filteredOffers = filterOffers(offers, model.Filters);

            return View();
        }

        private List<SimpleOfferViewModel> filterOffers(List<SimpleOfferViewModel> offers, Filters filters)
        {
            //TODO: IMPLEMENT IT!!!!!
            return offers;
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
