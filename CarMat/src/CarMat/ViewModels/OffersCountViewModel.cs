using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels
{
    public class OffersCountViewModel
    {
        public int CountAll { get; set; }
        public List<BrandOffersCount> brandsWithOffersCount { get; set; }
    }
}
