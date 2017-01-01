using CarMat.Models;
using System.Collections.Generic;

namespace CarMat.Repositories
{
    public interface IDemographicsRepository
    {
        Demographics GetDemographicsByCityAndProvinceName(string city, string province);
        Province GetProvinceByName(string province);
        List<string> GetAllProvincesName();
    }
}