using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public interface IUnitOfWork
    {
        IVehicleEquipmentRepository Equipment { get; }
        IVehicleModelRepository Models { get; }
        IOfferRepository Offers { get; }
        IUserRepository Users { get; }
        IDemographicsRepository Demographics { get; }

        void Complete();
        Task CompleteAsync();
    }
}