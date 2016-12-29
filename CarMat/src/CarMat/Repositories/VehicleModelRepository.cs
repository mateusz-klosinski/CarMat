using CarMat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private CMContext _context;

        public VehicleModelRepository(CMContext context)
        {
            _context = context;
        }

        public VehicleModel GetVehicleModel(string vehicleModelName)
        {
            return _context.VehicleModels
                    .Where(vm => vm.Name
                    .Equals(vehicleModelName))
                    .FirstOrDefault();
        }
    }
}
