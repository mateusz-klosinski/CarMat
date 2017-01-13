using CarMat.Repositories;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers
{
    public class StatisticsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public StatisticsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            var mostPopularOffers = _unitOfWork.Offers
                .GetFutureOffers(string.Empty)
                .Take(10)
                .ToList();

            return View(mostPopularOffers);
        }


        public IActionResult AverageBrandPrice()
        {
            var model = _unitOfWork.Models.GetAverageBrandPrices();

            return View(model);
        }

        public IActionResult CountOffers()
        {
            var model = _unitOfWork.Offers.GetOffersCountForActualMonth();

            return View(model);
        }

        public IActionResult Archive()
        {
            var model = _unitOfWork.Offers.GetFinishedOffers();

            return View(model);
        }


        public IActionResult UsersStats()
        {
           var model = _unitOfWork.Users.GetUsersOffersCount();

            return View(model);
        }
    }
}
