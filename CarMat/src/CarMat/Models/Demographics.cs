using System.Collections.Generic;

namespace CarMat.Models
{
    public class Demographics
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public ICollection<CMUser> User { get; set; }
    }
}