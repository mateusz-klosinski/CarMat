using CarMat.Models;
using CarMat.Repositories;
using CarMat.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Services
{
    public class OfferService : IOfferService
    {
        private IUnitOfWork _unitOfWork;
        private IVehicleService _vehicleService;
        private IWatchService _watchService;

        public OfferService(IUnitOfWork unitOfWork, IVehicleService vehicleService, IWatchService watchService)
        {
            _unitOfWork = unitOfWork;
            _vehicleService = vehicleService;
            _watchService = watchService;
        }



        public OfferDetailsViewModel GetOfferDetails(int offerId)
        {
            return _unitOfWork.Offers.GetOfferDetails(offerId);
        }



        public List<SimpleOfferViewModel> GetOffersWhichBelongsToUser(string username)
        {
            return _unitOfWork.Offers.GetOffersWhichBelongsToUser(username);
        }



        public List<SimpleOfferViewModel> GetOffersWatchedByUser(string username)
        {
            return _unitOfWork.Offers.GetOffersWatchedByUser(username);
        }




        public OfferFormViewModel CreateEmptyOfferWithAvailableEquipment()
        {
            return new OfferFormViewModel
            {
                Action = "Create",
                AvailableEquipment = _unitOfWork.Equipment.GetAvailableEquipmentNames()
            };
        }




        public OfferFormViewModel GetOfferToEditForUser(int offerId, string username)
        {
            return _unitOfWork.Offers.GetOfferToEditForUser(username, offerId);
        }



        public void AddAvailableEquipmentToOffer(OfferFormViewModel offer)
        {
            offer.AvailableEquipment = _unitOfWork.Equipment.GetAvailableEquipmentNames();
        }




        public void AddNewWatch(int offerId, string username)
        {
            _watchService.AddNewWatch(offerId, username);
        }

        public void StopWatchingOffer(int offerId, string username)
        {
            _watchService.RemoveWatch(offerId, username);
        }


        public void CreateNewOffer(string username, OfferFormViewModel model)
        {
            var user = _unitOfWork.Users.GetUserIncludingHisOffers(username);

            Offer offer = createNewOfferFromModel(model, user);

            _unitOfWork.Offers.CreateNewOfferForUser(user, offer);
            _unitOfWork.Complete();
        }

        private Offer createNewOfferFromModel(OfferFormViewModel model, CMUser user)
        {
            return new Offer
            {
                User = user,
                DateAdded = DateTime.Today,
                DateFinished = model.DateFinished,
                Description = model.Description,
                Price = decimal.Parse(model.Price),
                Title = model.Title,
                Vehicle = _vehicleService.CreateNewVehicleFromModel(model),
            };
        }


        public bool UpdateOfferForUser(int offerId, string username, OfferFormViewModel model)
        {
            var offer = _unitOfWork.Offers.GetOfferForUser(offerId, username);

            if (offer != null)
            {
                updateGivenOffer(model, offer);

                _unitOfWork.Offers.UpdateOffer(offer);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }

        private void updateGivenOffer(OfferFormViewModel model, Offer offer)
        {
            offer.Price = decimal.Parse(model.Price);
            offer.Title = model.Title;
            offer.DateFinished = model.DateFinished;

            _vehicleService.UpdateExistingOffersVehicle(model, offer);
        }


        public bool DeleteOfferForUser(int offerId, string username)
        {
            var offer = _unitOfWork.Offers.GetOfferForUser(offerId, username);

            if (offer != null)
            {
                _unitOfWork.Offers.DeleteOffer(offer);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }

        public bool FinishOfferForUser(int offerId, string username)
        {
            var offer = _unitOfWork.Offers.GetOfferForUser(offerId, username);

            if (offer != null)
            {
                offer.DateFinished = DateTime.Today - TimeSpan.FromDays(1);
                _unitOfWork.Offers.UpdateOffer(offer);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }


    }
}
