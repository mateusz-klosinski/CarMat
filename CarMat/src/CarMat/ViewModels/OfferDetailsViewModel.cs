using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels
{
    public class OfferDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateFinished { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }


        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public int EngineCapacity { get; set; }
        public bool isDamaged { get; set; }
        public bool isRegistered { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleBrand { get; set; }
        public List<string> VehicleEquipment { get; set; }


        public string UserName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
