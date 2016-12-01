using CarMat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers.API
{
    [Route("api")]
    public class OffersController : Controller
    {
        private CMContext _context;

        public OffersController(CMContext context)
        {
            _context = context;
        }

        [HttpGet("GetBrands")]
        public IActionResult GetBrandAutoComplete()
        {
            var brands = _context.VehicleBrands
                .Select(b => b.Name)
                .ToList();

            return Ok(brands);
        }

        [HttpGet("GetModels/{brandName}")]
        public IActionResult GerModelsAutoComplete(string brandName)
        {
            var brand = _context.VehicleBrands
                .Where(b => b.Name.Equals(brandName))
                .FirstOrDefault();

            if (brand != null)
            {
                var models = _context.VehicleModels
                    .Where(m => m.BrandId == brand.Id)
                    .Select(m => m.Name)
                    .ToList();

                return Ok(models);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
