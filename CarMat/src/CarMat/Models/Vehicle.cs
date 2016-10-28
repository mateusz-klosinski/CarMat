using System.Collections.Generic;

namespace CarMat.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public int ProductionYear { get; set; }

        public int Mileage { get; set; }

        public int EngineCapacity { get; set; }

        public bool isDamaged { get; set; }

        public bool isRegistered { get; set; }

        public int OfferId { get; set; }

        public Offer Offer { get; set; }

        public VehicleModel Model { get; set; }

        public ICollection<VehicleVehicleEquipment> VehicleVehicleEquipment { get; set; }
    }
}