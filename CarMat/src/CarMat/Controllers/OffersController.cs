using CarMat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers
{
    public class OffersController : Controller
    {
        public IActionResult Create()
        {
            OfferViewModel offer = new OfferViewModel();

            return View(offer);
        }
    }
}
