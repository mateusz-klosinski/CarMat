using CarMat.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public class VehicleEquipmentRepository : IVehicleEquipmentRepository
    {
        private CMContext _context;

        public VehicleEquipmentRepository(CMContext context)
        {
            _context = context;
        }

        public void CreateNewVehicleEquipmentForVehicle(VehicleVehicleEquipment newEquipment, Vehicle vehicle)
        {
            vehicle.VehicleVehicleEquipment.Add(newEquipment);
            _context.VehicleVehicleEquipment.Add(newEquipment);
        }

        public void RemoveVehicleEquipmentFromVehicle(VehicleVehicleEquipment equipment, Vehicle vehicle)
        {
            vehicle.VehicleVehicleEquipment.Remove(equipment);
            _context.VehicleVehicleEquipment.Remove(equipment);
        }

        public MultiSelectList GetAvailableEquipmentNames()
        {
            return new MultiSelectList(
                _context.VehicleEquipments
                    .Select(ve => ve.Name)
                    .ToList());
        }

        public List<VehicleEquipment> GetEquipmentMatchGivenNames(List<string> vehicleEquipmentNames)
        {
           return _context.VehicleEquipments
                   .Where(ve => vehicleEquipmentNames
                   .Any(e => e.Equals(ve.Name)))
                   .ToList();
        }
    }
}
