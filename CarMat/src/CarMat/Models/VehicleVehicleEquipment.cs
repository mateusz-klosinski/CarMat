using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Models
{
    public class VehicleVehicleEquipment
    {
        public int VehicleId { get; set; }

        public int EquipmentId { get; set; }

        public Vehicle Vehicle { get; set; }

        public VehicleEquipment Equipment { get; set; }
    }
}
