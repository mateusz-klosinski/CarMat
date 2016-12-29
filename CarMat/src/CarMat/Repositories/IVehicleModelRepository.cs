using CarMat.Models;

namespace CarMat.Repositories
{
    public interface IVehicleModelRepository
    {
        VehicleModel GetVehicleModel(string vehicleModelName);
    }
}