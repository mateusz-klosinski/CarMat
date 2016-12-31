using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Models
{
    public class Watch
    {
        public int Id { get; set; }

        public string WatcherId { get; set; }

        public int WatchedOfferId { get; set; }

        public CMUser Watcher { get; set; }

        public Offer WatchedOffer { get; set; }
    }
}
