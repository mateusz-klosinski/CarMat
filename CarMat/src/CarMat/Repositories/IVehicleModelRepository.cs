﻿using CarMat.Models;
using System.Collections.Generic;

namespace CarMat.Repositories
{
    public interface IVehicleModelRepository
    {
        VehicleModel GetVehicleModel(string vehicleModelName);
        List<string> GetAllVehicleBrandNames();
        VehicleBrand GetBrandByName(string brandName);
        List<string> GetVehicleModelNames(int brandId);
    }
}