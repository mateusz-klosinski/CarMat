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
        private OfferService _offerService;
        private NotificationService _notificationService;

        public OffersController(OfferService offerService, NotificationService notificationService)
        {
            _offerService = offerService;
            _notificationService = notificationService;
        }

        [Route("Offers/Details/{offerId}")]
        public IActionResult Details(int offerId)
        {
            var username = User.Identity.Name;
            var offer = _offerService.GetOfferDetails(offerId, username);
            _offerService.IncrementViewCounter(offerId);

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

            var offers = _offerService.GetOffersWhichBelongsToUser(username);

            return View(offers);
        }

        [Authorize]
        public IActionResult Watched()
        {
            var username = User.Identity.Name;

            var offers = _offerService.GetOffersWatchedByUser(username);

            return View(offers);
        }

        [Authorize]
        [Route("Offers/StopWatch/{offerId}")]
        public IActionResult StopWatch(int offerId)
        {
            var username = User.Identity.Name;

            _offerService.StopWatchingOffer(offerId, username);

            return RedirectToAction("Watched");
        }

        [Authorize]
        public IActionResult Create()
        {
            OfferFormViewModel offer = _offerService.CreateEmptyOfferWithAvailableEquipment();

            return View(offer);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(OfferFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;

                _offerService.CreateNewOffer(username, model);

                return RedirectToAction("Mine");
            }
            else
            {
                _offerService.AddAvailableEquipmentToOffer(model);
                return View(model);
            }
        }

        [Authorize]
        [Route("Offers/Edit/{offerId}")]
        public IActionResult Edit(int offerId)
        {
            var username = User.Identity.Name;

            var offerToEdit = _offerService.GetOfferToEditForUser(offerId, username);
            _offerService.AddAvailableEquipmentToOffer(offerToEdit);

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

                var isUpdated = _offerService.UpdateOfferForUser(offerId, username, model);

                if (isUpdated)
                {
                    _notificationService.CreateNotificationsForAllWatchers(offerId, NotificationType.OfferUpdated);
                }

                return RedirectToAction("Mine");
            }
            else
                return RedirectToAction("Mine");
        }


        [Authorize]
        [Route("Offers/Finish/{offerId}")]
        public IActionResult Finish(int offerId)
        {
            var username = User.Identity.Name;

            var isFinished = _offerService.FinishOfferForUser(offerId, username);

            if (isFinished)
            {
                _notificationService.CreateNotificationsForAllWatchers(offerId, NotificationType.OfferDeleted);
            }

            return RedirectToAction("Mine");
        }

        [Authorize]
        [Route("Offers/Delete/{offerId}")]
        public IActionResult Delete(int offerId)
        {
            var username = User.Identity.Name;

            _offerService.DeleteOfferForUser(offerId, username);

            return RedirectToAction("Mine");
        }
    }
}
