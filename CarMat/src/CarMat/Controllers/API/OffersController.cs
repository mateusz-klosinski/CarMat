using CarMat.Models;
using CarMat.Repositories;
using CarMat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers.API
{
    [Route("api/Offers")]
    public class OffersController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private WatchService _watchService;

        public OffersController(IUnitOfWork unitOfWork, WatchService watchService)
        {
            _unitOfWork = unitOfWork;
            _watchService = watchService;
        }

        [HttpGet("GetBrands")]
        public IActionResult GetBrandAutoComplete()
        {
            var brands = _unitOfWork.Models.GetAllVehicleBrandNames();

            return Ok(brands);
        }

        [HttpGet("GetModels/{brandName}")]
        public IActionResult GerModelsAutoComplete(string brandName)
        {
            var brand = _unitOfWork.Models.GetBrandByName(brandName);

            if (brand != null)
            {
                var models = _unitOfWork.Models.GetVehicleModelNames(brand.Id);

                return Ok(models);
            }
            else
            {
                return BadRequest();
            }
        }


        [Authorize]
        [HttpPost("Watch/{offerId}")]
        public IActionResult Watch(int offerId)
        {
            var username = User.Identity.Name;

            _watchService.AddNewWatch(offerId, username);

            return Ok();
        }


        [Authorize]
        [HttpPost("StopWatching/{offerId}")]
        public IActionResult StopWatching(int offerId)
        {
            var username = User.Identity.Name;

            _watchService.RemoveWatch(offerId, username);

            return Ok();
        }
    }
}
