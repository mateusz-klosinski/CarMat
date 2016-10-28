using System.Collections.Generic;

namespace CarMat.Models
{
    public class Province
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Demographics> Demographics { get; set; }
    }
}