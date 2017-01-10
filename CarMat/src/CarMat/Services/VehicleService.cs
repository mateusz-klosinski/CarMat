using CarMat.Models;
using CarMat.Repositories;
using CarMat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Services
{
    public class VehicleService
    {
        private IUnitOfWork _unitOfWork;



        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        public Vehicle CreateNewVehicleFromModel(OfferFormViewModel model)
        {
            Vehicle newVehicle = new Vehicle
            {

                EngineCapacity = model.EngineCapacity,
                isDamaged = model.isDamaged,
                isRegistered = model.isRegistered,
                Mileage = model.Mileage,
                Model = _unitOfWork.Models.GetVehicleModel(model.VehicleModel),
                ProductionYear = model.ProductionYear,
                VehicleVehicleEquipment = new List<VehicleVehicleEquipment>(),
            };

            if (model.VehicleEquipment != null)
            {
                addEquipmentToNewVehicle(model.VehicleEquipment, newVehicle);
            }

            return newVehicle;
        }


        private void addEquipmentToNewVehicle(List<string> equipmentNames, Vehicle vehicle)
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





        public void UpdateExistingOffersVehicle(OfferFormViewModel model, Offer offer)
        {
            updateVehicleWithoutEquipment(model, offer);

            if (model.VehicleEquipment != null)
            {
                updateVehicleEquipment(model.VehicleEquipment, offer);
            }
        }

        private void updateVehicleWithoutEquipment(OfferFormViewModel model, Offer offer)
        {
            offer.Vehicle.EngineCapacity = model.EngineCapacity;
            offer.Vehicle.isDamaged = model.isDamaged;
            offer.Vehicle.isRegistered = model.isRegistered;
            offer.Vehicle.Mileage = model.Mileage;
            offer.Vehicle.Model = _unitOfWork.Models.GetVehicleModel(model.VehicleModel);
            offer.Vehicle.ProductionYear = model.ProductionYear;
        }

        private void updateVehicleEquipment(List<string> vehicleEquipment, Offer offer)
        {
            List<VehicleEquipment> equipmentForVehicle = _unitOfWork.Equipment.GetEquipmentMatchGivenNames(vehicleEquipment);

            addNewEquipmentToExistingVehicle(offer.Vehicle, equipmentForVehicle);
            removeEquipmentFromExistingVehicle(offer.Vehicle, equipmentForVehicle);
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

    }
}
