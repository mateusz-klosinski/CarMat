using CarMat.Models;
using CarMat.Repositories;
using CarMat.Services;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers
{
    public class OffersController : Controller
    {
        private IOfferService _service;


        public OffersController(IOfferService service)
        {
            _service = service;
        }

        [Route("Offers/Details/{offerId}")]
        public IActionResult Details(int offerId)
        {
            var offer = _service.GetOfferDetails(offerId);

            if (offer != null)
            {
                return View(offer);
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Mine()
        {
            var username = User.Identity.Name;

            var offers = _service.GetOffersWhichBelongsToUser(username);

            return View(offers);
        }

        [Authorize]
        public IActionResult Create()
        {
            OfferFormViewModel offer = _service.CreateEmptyOfferWithAvailableEquipment();

            return View(offer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(OfferFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;

                _service.CreateNewOffer(username, model);

                return RedirectToAction("Mine");
            }
            else
            {
                _service.AddAvailableEquipmentToOffer(model);
                return View(model);
            }
        }

        [Authorize]
        [Route("Offers/Edit/{offerId}")]
        public IActionResult Edit(int offerId)
        {
            var username = User.Identity.Name;

            var offerToEdit = _service.GetOfferToEditForUser(offerId, username);
            _service.AddAvailableEquipmentToOffer(offerToEdit);

            if (offerToEdit != null)
            {
                return View("Create", offerToEdit);
            }
            else
                return RedirectToAction("Mine");
        }

        [Authorize]
        [HttpPost]
        [Route("Offers/Edit/{offerId}")]
        public IActionResult Edit(OfferFormViewModel model, int offerId)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;

                _service.UpdateOfferForUser(offerId, username, model);

                return RedirectToAction("Mine");
            }
            else
                return RedirectToAction("Mine");
        }


        [Authorize]
        [Route("Offers/Delete/{offerId}")]
        public IActionResult Delete(int offerId)
        {
            var username = User.Identity.Name;

            _service.DeleteOfferForUser(offerId, username);

            return RedirectToAction("Mine");
        }
    }
}
