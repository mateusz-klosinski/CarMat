using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels
{
    public class OffersWithFiltersViewModel
    {
        public List<SimpleOfferViewModel> Offers { get; set; }

        public Filters Filters { get; set; }
    }
}
