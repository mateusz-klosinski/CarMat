using CarMat.Models;
using CarMat.ViewModels;
using Microsoft.EntityFrameworkCore;
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


        public List<AverageBrandPriceViewModel> GetAverageBrandPrices()
        {
            var offers = _context.Offers
                .Include(o => o.Vehicle.Model.Brand)
                .Where(o => o.DateFinished >= DateTime.Today)
                .ToList();

            var brands = _context.VehicleBrands
                .ToList();

            List<AverageBrandPriceViewModel> averageBrandPrices = new List<AverageBrandPriceViewModel>();


            brands.ForEach(b => 
            {
                if (offers.Any(o => o.Vehicle.Model.Brand == b))
                {
                    string averagePrice = offers
                        .Where(o => o.Vehicle.Model.Brand == b)
                        .Average(o => o.Price)
                        .ToString("c");


                    averageBrandPrices.Add(new AverageBrandPriceViewModel
                    {
                        Brand = b.Name,
                        AveragePrice = averagePrice,
                    });
                }
            });

            return averageBrandPrices.OrderBy(abp => abp.Brand).ToList();
        }
    }
}
