using CarMat.Models;
using CarMat.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers.API
{
    [Route("api/Demographics")]
    public class DemographicsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public DemographicsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetProvinces")]
        public IActionResult GetProvinces()
        {
            var provinces = _unitOfWork.Demographics.GetAllProvincesName();

            return Ok(provinces);
        }
    }
}
