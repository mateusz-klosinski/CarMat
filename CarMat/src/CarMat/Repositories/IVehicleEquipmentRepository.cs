using System.Collections.Generic;
using CarMat.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarMat.Repositories
{
    public interface IVehicleEquipmentRepository
    {
        void CreateNewVehicleEquipmentForVehicle(VehicleVehicleEquipment newEquipment, Vehicle vehicle);
        MultiSelectList GetAvailableEquipmentNames();
        List<VehicleEquipment> GetEquipmentMatchGivenNames(List<string> vehicleEquipmentNames);
        void RemoveVehicleEquipmentFromVehicle(VehicleVehicleEquipment equipment, Vehicle vehicle);
    }
}