using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarMat.Models
{
    public class CMUser : IdentityUser
    {
        public ICollection<Offer> Offers { get; set; }

        public ICollection<Watch> Watches { get; set; }

        public int DemographicsId { get; set; }

        public Demographics Demographics { get; set; }
    }
}
