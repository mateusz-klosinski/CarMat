using CarMat.Models;
using CarMat.ViewModels;

namespace CarMat.Services
{
    public interface IVehicleService
    {
        Vehicle CreateNewVehicleFromModel(OfferFormViewModel model);
        void UpdateExistingOffersVehicle(OfferFormViewModel model, Offer offer);
    }
}