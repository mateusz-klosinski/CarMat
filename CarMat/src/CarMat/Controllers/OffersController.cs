using CarMat.Models;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [Route("offers/details/{offerId}")]
        public IActionResult Details(int offerId)
        {
            var offer = _context.Offers
                .Include(o => o.Vehicle)
                .Include(o => o.User)
                .Include(o => o.Vehicle.Model)
                .Include(o => o.Vehicle.Model.Brand)
                .Where(o => o.Id == offerId)
                .FirstOrDefault();


            if (offer != null)
            {
                return View(offer);
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Mine()
        {
            var username = User.Identity.Name;
            var offers = _context.Offers
                .Include(o => o.Vehicle)
                .Include(o => o.User)
                .Where(o => o.User.UserName
                .Equals(username))
                .ToList();

            return View(offers);
        }

        [Authorize]
        public IActionResult Create()
        {
            OfferViewModel offer = new OfferViewModel();

            return View(offer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(OfferViewModel model)
        {
            var userName = User.Identity.Name;
            var user = _context.Users
                .Include(u => u.Offers)
                .Where(u => u.UserName
                .Equals(userName))
                .FirstOrDefault();

            if (ModelState.IsValid)
            {
                Offer offer = new Offer();
                offer.User = user;
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


                user.Offers.Add(offer);
                _context.Add(offer);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else return View(model);
        }
    }
}
