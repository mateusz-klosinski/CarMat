using CarMat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public class DemographicsRepository : IDemographicsRepository
    {
        private CMContext _context;

        public DemographicsRepository(CMContext context)
        {
            _context = context;
        }

        public List<string> GetAllProvincesName()
        {
            return _context.Provinces
                .Select(p => p.Name)
                .ToList();
        }

        public Demographics GetDemographicsByCityAndProvinceName(string city, string province)
        {
            return _context.Demographics
                    .Where(d => d.City.Equals(city, StringComparison.CurrentCultureIgnoreCase) &&
                    d.Province.Name.Equals(province, StringComparison.CurrentCultureIgnoreCase))
                    .FirstOrDefault();
        }


        public Province GetProvinceByName(string province)
        {
            return _context.Provinces
                    .Where(p => p.Name
                    .Equals(province, StringComparison.CurrentCultureIgnoreCase))
                    .FirstOrDefault();
        }


    }
}
