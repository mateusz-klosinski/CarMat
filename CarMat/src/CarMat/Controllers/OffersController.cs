using CarMat.Models;
using CarMat.Repositories;
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
        private UnitOfWork _unitOfWork;


        public OffersController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Offers/Details/{offerId}")]
        public IActionResult Details(int offerId)
        {
            var offer = _unitOfWork.Offers.GetDetailsForOffer(offerId);


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

            var offers = _unitOfWork.Offers.GetOffersWhichBelongsToUser(username);

            return View(offers);
        }

        [Authorize]
        public IActionResult Create()
        {
            OfferFormViewModel offer = new OfferFormViewModel
            {
                Action = "Create",
                AvailableEquipment = _unitOfWork.Equipment.GetAvailableEquipmentNames()
            };

            return View(offer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(OfferFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;

                var user = _unitOfWork.Users.GetUserIncludingHisOffers(username);

                var vehicleModel = _unitOfWork.Models.GetVehicleModel(model.VehicleModel);

                List<VehicleEquipment> equipmentForVehicle = null;
                if (model.VehicleEquipment != null)
                {
                    equipmentForVehicle = _unitOfWork.Equipment.GetEquipmentMatchGivenNames(model.VehicleEquipment);
                }


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

                if (equipmentForVehicle != null)
                {
                    equipmentForVehicle
                        .ForEach(efv => offer.Vehicle.VehicleVehicleEquipment
                        .Add(new VehicleVehicleEquipment
                        {
                            Vehicle = offer.Vehicle,
                            Equipment = efv,
                        }));
                }


                _unitOfWork.Offers.CreateNewOfferForUser(user, offer);
                _unitOfWork.Complete();

                return RedirectToAction("Mine");
            }
            else
            {
                model.AvailableEquipment = _unitOfWork.Equipment.GetAvailableEquipmentNames();
                return View(model);
            }
        }

        [Authorize]
        [Route("Offers/Edit/{offerId}")]
        public IActionResult Edit(int offerId)
        {
            var username = User.Identity.Name;

            var offerToEdit = _unitOfWork.Offers.GetOfferToEditForUser(username, offerId);
            offerToEdit.AvailableEquipment = _unitOfWork.Equipment.GetAvailableEquipmentNames();

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

                var offer = _unitOfWork.Offers.GetOfferForUser(offerId, username);

                List<VehicleEquipment> equipmentForVehicle = null;
                if (model.VehicleEquipment != null)
                {
                    equipmentForVehicle = _unitOfWork.Equipment.GetEquipmentMatchGivenNames(model.VehicleEquipment);
                }



                if (offer != null)
                {
                    offer.Price = decimal.Parse(model.Price);
                    offer.Title = model.Title;
                    offer.Vehicle.EngineCapacity = model.EngineCapacity;
                    offer.Vehicle.isDamaged = model.isDamaged;
                    offer.Vehicle.isRegistered = model.isRegistered;
                    offer.Vehicle.Mileage = model.Mileage;
                    offer.Vehicle.Model = _unitOfWork.Models.GetVehicleModel(model.VehicleModel);
                    offer.Vehicle.ProductionYear = model.ProductionYear;

                    if (equipmentForVehicle != null)
                    {
                        foreach (var equipment in equipmentForVehicle)
                        {
                            if (!offer.Vehicle.VehicleVehicleEquipment.Any(ve => ve.EquipmentId == equipment.Id))
                            {
                                var newEquipment = new VehicleVehicleEquipment
                                {
                                    Vehicle = offer.Vehicle,
                                    Equipment = equipment,
                                };

                                _unitOfWork.Equipment.CreateNewVehicleEquipmentForVehicle(newEquipment, offer.Vehicle);
                            }
                        }

                        foreach (var equipment in offer.Vehicle.VehicleVehicleEquipment.ToList())
                        {
                            if (!equipmentForVehicle.Any(e => e.Id == equipment.EquipmentId))
                            {
                                _unitOfWork.Equipment.RemoveVehicleEquipmentFromVehicle(equipment, offer.Vehicle);
                            }
                        }
                    }


                    _unitOfWork.Offers.UpdateOffer(offer);
                    _unitOfWork.Complete();

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

            var offer = _unitOfWork.Offers.GetOfferForUser(offerId, username);

            if (offer != null)
            {
                _unitOfWork.Offers.DeleteOffer(offer);
                _unitOfWork.Complete();
                return RedirectToAction("Mine");
            }
            return RedirectToAction("Mine");
        }
    }
}
