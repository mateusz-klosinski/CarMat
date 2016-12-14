using CarMat.Models;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers
{
    public class OffersController : Controller
    {
        private CMContext _context;

        public OffersController(CMContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            OfferViewModel offer = new OfferViewModel();

            return View(offer);
        }

        [HttpPost]
        public IActionResult Create(OfferViewModel model)
        {
            if (ModelState.IsValid)
            {
                Offer offer = new Offer();

                offer.DateAdded = DateTime.Today;
                offer.DateFinished = model.DateFinished;
                offer.Description = model.Description;
                offer.Price = model.Price;
                offer.Title = model.Title;
                offer.Vehicle = new Vehicle
                {
                    EngineCapacity = model.Vehicle.EngineCapacity,
                    isDamaged = model.Vehicle.isDamaged,
                    isRegistered = model.Vehicle.isRegistered,
                    Mileage = model.Vehicle.Mileage,
                    Model = _context.VehicleModels.Where(vm => vm.Name.Equals(model.Vehicle.VehicleModel)).FirstOrDefault(),
                    ProductionYear = model.Vehicle.ProductionYear,
                };

                _context.Add(offer);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else return View(model);
        }
    }
}
