using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.ViewModels
{
    public class SimpleOfferViewModel
    {
        public int Id { get; set; }


        public string Title { get; set; }
        public decimal Price { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public int EngineCapacity { get; set; }
        public DateTime DateFinished { get; set;}

        public bool IsWatched { get; set; }
        public bool BelongsToCurrentUser { get; set; }

        public int ViewCounter { get; set; }
    }
}
