using CarMat.Models;
using CarMat.Repositories;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Services
{
    public class OfferService : IOfferService
    {
        private IUnitOfWork _unitOfWork;

        public OfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public OfferDetailsViewModel GetOfferDetails(int offerId)
        {
            return _unitOfWork.Offers.GetOfferDetails(offerId);
        }



        public List<SimpleOfferViewModel> GetOffersWhichBelongsToUser(string username)
        {
            return _unitOfWork.Offers.GetOffersWhichBelongsToUser(username);
        }



        public OfferFormViewModel CreateEmptyOfferWithAvailableEquipment()
        {
            return new OfferFormViewModel
            {
                Action = "Create",
                AvailableEquipment = _unitOfWork.Equipment.GetAvailableEquipmentNames()
            };
        }


        public OfferFormViewModel GetOfferToEditForUser(int offerId, string username)
        {
            return _unitOfWork.Offers.GetOfferToEditForUser(username, offerId);
        }

        public void AddAvailableEquipmentToOffer(OfferFormViewModel offer)
        {
            offer.AvailableEquipment = _unitOfWork.Equipment.GetAvailableEquipmentNames();
        }



        public void CreateNewOffer(string username, OfferFormViewModel model)
        {
            var user = _unitOfWork.Users.GetUserIncludingHisOffers(username);

            Offer offer = createNewOfferFromModel(model, user);

            _unitOfWork.Offers.CreateNewOfferForUser(user, offer);
            _unitOfWork.Complete();
        }

        private Offer createNewOfferFromModel(OfferFormViewModel model, CMUser user)
        {
            Offer offer = createNewOfferFromModelWithoutVehicleEquipment(model, user);

            if (model.VehicleEquipment != null)
            {
                addEquipmentToVehicle(model.VehicleEquipment, offer.Vehicle);
            }

            return offer;
        }

        private Offer createNewOfferFromModelWithoutVehicleEquipment(OfferFormViewModel model, CMUser user)
        {
            return new Offer
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
                    Model = _unitOfWork.Models.GetVehicleModel(model.VehicleModel),
                    ProductionYear = model.ProductionYear,
                    VehicleVehicleEquipment = new List<VehicleVehicleEquipment>(),
                }
            };
        }

        private void addEquipmentToVehicle(List<string> equipmentNames, Vehicle vehicle)
        {
            List<VehicleEquipment> equipmentForVehicle = _unitOfWork.Equipment.GetEquipmentMatchGivenNames(equipmentNames);

            foreach (var equipment in equipmentForVehicle)
            {
                vehicle.VehicleVehicleEquipment.Add(new VehicleVehicleEquipment
                {
                    Vehicle = vehicle,
                    Equipment = equipment,
                });
            }

        }



        public void UpdateOfferForUser(int offerId, string username, OfferFormViewModel model)
        {
            var offer = _unitOfWork.Offers.GetOfferForUser(offerId, username);

            if (offer != null)
            {
                updateGivenOffer(model, offer);

                _unitOfWork.Offers.UpdateOffer(offer);
                _unitOfWork.Complete();
            }
        }

        private void updateGivenOffer(OfferFormViewModel model, Offer offer)
        {
            updateOfferWithoutEquipment(model, offer);

            if (model.VehicleEquipment != null)
            {
                updateVehicleEquipment(model, offer);
            }
        }


        private void updateOfferWithoutEquipment(OfferFormViewModel model, Offer offer)
        {
            offer.Price = decimal.Parse(model.Price);
            offer.Title = model.Title;
            offer.Vehicle.EngineCapacity = model.EngineCapacity;
            offer.Vehicle.isDamaged = model.isDamaged;
            offer.Vehicle.isRegistered = model.isRegistered;
            offer.Vehicle.Mileage = model.Mileage;
            offer.Vehicle.Model = _unitOfWork.Models.GetVehicleModel(model.VehicleModel);
            offer.Vehicle.ProductionYear = model.ProductionYear;
        }

        private void updateVehicleEquipment(OfferFormViewModel model, Offer offer)
        {
            List<VehicleEquipment> equipmentForVehicle = _unitOfWork.Equipment.GetEquipmentMatchGivenNames(model.VehicleEquipment);

            addNewEquipmentToExistingVehicle(offer.Vehicle, equipmentForVehicle);
            removeEquipmentFromExistingVehicle(offer.Vehicle, equipmentForVehicle);
        }

        private void removeEquipmentFromExistingVehicle(Vehicle vehicle, List<VehicleEquipment> equipmentForVehicle)
        {
            foreach (var equipment in vehicle.VehicleVehicleEquipment.ToList())
            {
                if (!equipmentForVehicle.Any(e => e.Id == equipment.EquipmentId))
                {
                    _unitOfWork.Equipment.RemoveVehicleEquipmentFromVehicle(equipment, vehicle);
                }
            }
        }

        private void addNewEquipmentToExistingVehicle(Vehicle vehicle, List<VehicleEquipment> equipmentForVehicle)
        {
            foreach (var equipment in equipmentForVehicle)
            {
                if (!vehicle.VehicleVehicleEquipment.Any(ve => ve.EquipmentId == equipment.Id))
                {
                    var newEquipment = new VehicleVehicleEquipment
                    {
                        Vehicle = vehicle,
                        Equipment = equipment,
                    };

                    _unitOfWork.Equipment.AddNewVehicleEquipmentToVehicle(newEquipment, vehicle);
                }
            }
        }


        public void DeleteOfferForUser(int offerId, string username)
        {
            var offer = _unitOfWork.Offers.GetOfferForUser(offerId, username);

            if (offer != null)
            {
                _unitOfWork.Offers.DeleteOffer(offer);
                _unitOfWork.Complete();
            }
        }

    }
}
