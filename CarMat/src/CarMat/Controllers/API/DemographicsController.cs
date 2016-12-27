using CarMat.Models;
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
        private CMContext _context;

        public DemographicsController(CMContext context)
        {
            _context = context;
        }

        [HttpGet("GetProvinces")]
        public IActionResult GetProvinces()
        {
            var provinces = _context.Provinces
                .Select(p => p.Name)
                .ToList();

            return Ok(provinces);
        }
    }
}
