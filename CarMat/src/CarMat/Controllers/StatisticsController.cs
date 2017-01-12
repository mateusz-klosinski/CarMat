using CarMat.Repositories;
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
    }
}
