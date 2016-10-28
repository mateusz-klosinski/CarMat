using System.Collections.Generic;

namespace CarMat.Models
{
    public class VehicleEquipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<VehicleVehicleEquipment> VehicleVehicleEquipment { get; set; }
    }
}