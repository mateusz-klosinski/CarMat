using System.Collections.Generic;
using CarMat.Models;
using CarMat.ViewModels;

namespace CarMat.Repositories
{
    public interface IOfferRepository
    {
        void CreateNewOfferForUser(CMUser user, Offer offer);
        void DeleteOffer(Offer offer);
        OfferDetailsViewModel GetOfferDetails(int offerId);
        List<SimpleOfferViewModel> GetFutureOffers(string username);
        Offer GetOfferForUser(int offerId, string username);
        Offer GetOfferById(int offerId);
        List<SimpleOfferViewModel> GetOffersWhichBelongsToUser(string username);
        OfferFormViewModel GetOfferToEditForUser(string username, int offerId);
        void UpdateOffer(Offer offer);
        List<SimpleOfferViewModel> GetOffersWatchedByUser(string username);
        List<SimpleOfferViewModel> GetFutureOffersThatContainsQuery(string username, string query);
    }
}