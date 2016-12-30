using CarMat.Models;

namespace CarMat.Repositories
{
    public interface IDemographicsRepository
    {
        Demographics GetDemographicsByCityAndProvinceName(string city, string province);
        Province GetProvinceByName(string province);
    }
}