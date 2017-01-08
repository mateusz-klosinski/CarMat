using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels
{
    public class Filters
    {

        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }

        public int EngineCapacityFrom { get; set; }
        public int EngineCapacityTo { get; set; }

        public int ProductionYearFrom { get; set; }
        public int ProductionYearTo { get; set; }

        public bool IsRegistered { get; set; }

        public bool IsDamaged { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleBrand { get; set; }
    }
}
