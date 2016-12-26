using CarMat.Models;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Route("Offers/Details/{offerId}")]
        public IActionResult Details(int offerId)
        {
            var offer = _context.Offers
                .Include(o => o.Vehicle)
                .Include(o => o.User)
                .Include(o => o.Vehicle.Model)
                .Include(o => o.Vehicle.Model.Brand)
                .Include(o => o.Vehicle.VehicleVehicleEquipment)
                .Where(o => o.Id == offerId)
                .Select(o => new OfferDetailsViewModel
                {
                    Id = o.Id,
                    DateAdded = o.DateAdded,
                    DateFinished = o.DateFinished,
                    Description = o.Description,
                    Email = o.User.Email,
                    EngineCapacity = o.Vehicle.EngineCapacity,
                    isDamaged = o.Vehicle.isDamaged,
                    isRegistered = o.Vehicle.isRegistered,
                    Mileage = o.Vehicle.Mileage,
                    Price = o.Price,
                    ProductionYear = o.Vehicle.ProductionYear,
                    Title = o.Title,
                    UserName = o.User.UserName,
                    VehicleBrand = o.Vehicle.Model.Brand.Name,
                    VehicleModel = o.Vehicle.Model.Name,

                    VehicleEquipment = o.Vehicle.VehicleVehicleEquipment
                        .Select(vve => vve.Equipment.Name)
                     .ToList(),
                })
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
                .Select(o => new SimpleOfferViewModel
                {
                    EngineCapacity = o.Vehicle.EngineCapacity,
                    Id = o.Id,
                    Mileage = o.Vehicle.Mileage,
                    Price = o.Price,
                    ProductionYear = o.Vehicle.ProductionYear,
                    Title = o.Title,
                    DateFinished = o.DateFinished,
                })
                .ToList();

            return View(offers);
        }

        [Authorize]
        public IActionResult Create()
        {
            OfferFormViewModel offer = new OfferFormViewModel
            {
                Action = "Create",
                AvailableEquipment = new MultiSelectList(_context.VehicleEquipments
                    .Select(ve => ve.Name)
                    .ToList())
            };

            return View(offer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(OfferFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;

                var user = _context.Users
                    .Include(u => u.Offers)
                    .Where(u => u.UserName
                    .Equals(userName))
                    .FirstOrDefault();

                var vehicleModel = _context.VehicleModels
                    .Where(vm => vm.Name
                    .Equals(model.VehicleModel))
                    .FirstOrDefault();

                var equipmentForVehicle = _context.VehicleEquipments
                    .Where(ve => model.VehicleEquipment
                    .Any(e => e.Equals(ve.Name)))
                    .ToList();


                Offer offer = new Offer
                {
                    User = user,
                    DateAdded = DateTime.Today,
                    DateFinished = model.DateFinished,
                    Description = model.Description,
                    Price = decimal.Parse(model.Price),
                    Title = model.Title,
                    Vehicle = new Vehicle
                    {
                        EngineCapacity = model.EngineCapacity,
                        isDamaged = model.isDamaged,
                        isRegistered = model.isRegistered,
                        Mileage = model.Mileage,
                        Model = vehicleModel,
                        ProductionYear = model.ProductionYear,
                        VehicleVehicleEquipment = new List<VehicleVehicleEquipment>(),
                    }
                };


                equipmentForVehicle
                    .ForEach(efv => offer.Vehicle.VehicleVehicleEquipment
                    .Add(new VehicleVehicleEquipment
                    {
                        Vehicle = offer.Vehicle,
                        Equipment = efv,
                    }));


                user.Offers.Add(offer);
                _context.Add(offer);
                _context.SaveChanges();

                return RedirectToAction("Mine");
            }
            else
                return View(model);
        }

        [Authorize]
        [Route("Offers/Edit/{offerId}")]
        public IActionResult Edit(int offerId)
        {
            var username = User.Identity.Name;

            var offerToEdit = _context.Offers
                .Include(o => o.User)
                .Include(o => o.Vehicle)
                .Include(o => o.Vehicle.Model)
                .Include(o => o.Vehicle.Model.Brand)
                .Include(o => o.Vehicle.VehicleVehicleEquipment)
                .Where(o => o.User.UserName
                .Equals(username) && o.Id == offerId)
                .Select(o => new OfferFormViewModel
                {
                    Id = o.Id,
                    DateFinished = o.DateFinished,
                    Description = o.Description,
                    Price = o.Price.ToString("0"),
                    Title = o.Title,
                    EngineCapacity = o.Vehicle.EngineCapacity,
                    isDamaged = o.Vehicle.isDamaged,
                    isRegistered = o.Vehicle.isRegistered,
                    Mileage = o.Vehicle.Mileage,
                    ProductionYear = o.Vehicle.ProductionYear,
                    VehicleBrand = o.Vehicle.Model.Brand.Name,
                    VehicleModel = o.Vehicle.Model.Name,

                    VehicleEquipment = o.Vehicle.VehicleVehicleEquipment
                        .Select(ve => ve.Equipment.Name).ToList(),

                    AvailableEquipment = new MultiSelectList(_context.VehicleEquipments
                        .Select(ve => ve.Name)
                        .ToList()),

                    Action = "Edit",
                })
                .FirstOrDefault();


            if (offerToEdit != null)
            {
                return View("Create", offerToEdit);
            }
            else
                return RedirectToAction("Mine");
        }

        [Authorize]
        [HttpPost]
        [Route("Offers/Edit/{offerId}")]
        public IActionResult Edit(OfferFormViewModel model, int offerId)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;

                var offer = _context.Offers
                    .Include(o => o.Vehicle)
                    .Include(o => o.User)
                    .Include(o => o.Vehicle.VehicleVehicleEquipment)
                    .Where(o => o.Id == offerId && o.User.UserName.Equals(username))
                    .FirstOrDefault();

                var equipmentForVehicle = _context.VehicleEquipments
                    .Where(ve => model.VehicleEquipment
                    .Any(e => e.Equals(ve.Name)))
                    .ToList();



                if (offer != null)
                {
                    offer.Price = decimal.Parse(model.Price);
                    offer.Title = model.Title;
                    offer.Vehicle.EngineCapacity = model.EngineCapacity;
                    offer.Vehicle.isDamaged = model.isDamaged;
                    offer.Vehicle.isRegistered = model.isRegistered;
                    offer.Vehicle.Mileage = model.Mileage;
                    offer.Vehicle.Model = _context.VehicleModels
                        .Where(vm => vm.Name
                        .Equals(model.VehicleModel))
                        .FirstOrDefault();

                    offer.Vehicle.ProductionYear = model.ProductionYear;



                    foreach(var equipment in equipmentForVehicle)
                    {
                        if (!offer.Vehicle.VehicleVehicleEquipment.Any(ve => ve.EquipmentId == equipment.Id))
                        {
                            var newEquipment = new VehicleVehicleEquipment
                            {
                                Vehicle = offer.Vehicle,
                                Equipment = equipment,
                            };

                            offer.Vehicle.VehicleVehicleEquipment.Add(newEquipment);
                            _context.VehicleVehicleEquipment.Add(newEquipment);
                        }
                    }

                    foreach(var equipment in offer.Vehicle.VehicleVehicleEquipment.ToList())
                    {
                        if (!equipmentForVehicle.Any(e => e.Id == equipment.EquipmentId))
                        {
                            offer.Vehicle.VehicleVehicleEquipment.Remove(equipment);
                            _context.VehicleVehicleEquipment.Remove(equipment);
                        }
                    }

                    _context.Update(offer);
                    _context.SaveChanges();

                }
                return RedirectToAction("Mine");
            }
            else
                return RedirectToAction("Mine");
        }


        [Authorize]
        [Route("Offers/Delete/{offerId}")]
        public IActionResult Delete(int offerId)
        {
            var username = User.Identity.Name;

            var offer = _context.Offers
                .Include(o => o.User)
                .Include(o => o.Vehicle)
                .Where(o => o.User.UserName.Equals(username) && o.Id == offerId)
                .FirstOrDefault();

            if (offer != null)
            {
                _context.Offers.Remove(offer);
                _context.SaveChanges();
                return RedirectToAction("Mine");
            }
            return RedirectToAction("Mine");
        }
    }
}
