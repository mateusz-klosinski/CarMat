using System.Threading.Tasks;
using CarMat.Models;

namespace CarMat.Repositories
{
    public interface IUnitOfWork
    {
        IVehicleEquipmentRepository Equipment { get; }
        IVehicleModelRepository Models { get; }
        IOfferRepository Offers { get; }
        IUserRepository Users { get; }
        IDemographicsRepository Demographics { get; }
        IWatchRepository Watches { get; }

        void Complete();
        Task CompleteAsync();
    }
}