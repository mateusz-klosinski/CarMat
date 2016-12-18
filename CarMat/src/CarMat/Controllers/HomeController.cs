using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarMat.Models;
using Microsoft.EntityFrameworkCore;
using CarMat.ViewModels;

namespace CarMat.Controllers
{
    public class HomeController : Controller
    {
        private CMContext _context;

        public HomeController(CMContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var offersWithVehicles = _context.Offers
                .Include(o => o.Vehicle)
                .Select(o => new SimpleOfferViewModel
                {
                    EngineCapacity = o.Vehicle.EngineCapacity,
                    Id = o.Id,
                    Mileage = o.Vehicle.Mileage,
                    Price = o.Price,
                    ProductionYear = o.Vehicle.ProductionYear,
                    Title = o.Title
                })
                .ToList();

            return View(offersWithVehicles);
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
