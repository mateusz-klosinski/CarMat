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

        public List<string> GetAllVehicleBrandNames()
        {
            return _context.VehicleBrands
                .Select(vb => vb.Name)
                .ToList();
        }

        public VehicleBrand GetBrandByName(string brandName)
        {
            return _context.VehicleBrands
                .Where(b => b.Name.Equals(brandName))
                .FirstOrDefault();
        }

        public List<string> GetVehicleModelNames(int brandId)
        {
            return _context.VehicleModels
                    .Where(m => m.BrandId == brandId)
                    .Select(m => m.Name)
                    .ToList();
        }
    }
}
