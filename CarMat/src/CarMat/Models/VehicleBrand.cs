using System.Collections.Generic;

namespace CarMat.Models
{
    public class VehicleBrand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<VehicleModel> Models { get; set; }
    }
}