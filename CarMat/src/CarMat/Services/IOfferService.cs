using System.Collections.Generic;
using CarMat.ViewModels;

namespace CarMat.Services
{
    public interface IOfferService
    {
        void AddAvailableEquipmentToOffer(OfferFormViewModel offer);
        OfferFormViewModel CreateEmptyOfferWithAvailableEquipment();
        void CreateNewOffer(string username, OfferFormViewModel model);
        OfferDetailsViewModel GetOfferDetails(int offerId);
        List<SimpleOfferViewModel> GetOffersWhichBelongsToUser(string username);
        OfferFormViewModel GetOfferToEditForUser(int offerId, string username);
        void UpdateOfferForUser(int offerId, string username, OfferFormViewModel model);
        void DeleteOfferForUser(int offerId, string username);
        List<SimpleOfferViewModel> GetOffersWatchedByUser(string username);
        void AddNewWatch(int offerId, string username);
    }
}