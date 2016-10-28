using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Models
{
    public class Offer
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateFinished { get; set; }

        public decimal Price { get; set; }

        public string UserId { get; set; }

        public CMUser User { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
