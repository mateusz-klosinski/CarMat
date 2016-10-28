using System.Collections.Generic;

namespace CarMat.Models
{
    public class Demographics
    {
        public int Id { get; set; }

        public string City { get; set; }

        public int ProvinceId { get; set; }

        public Province Province { get; set; }

        public ICollection<CMUser> User { get; set; }
    }
}