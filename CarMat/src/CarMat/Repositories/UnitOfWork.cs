using CarMat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public class UnitOfWork
    {
        private CMContext _context;

        public OfferRepository Offers { get; private set; }
        public UserRepository Users { get; private set; }
        public VehicleEquipmentRepository Equipment { get; private set; }
        public VehicleModelRepository Models { get; private set; }


        public UnitOfWork(CMContext context)
        {
            _context = context;
            Offers = new OfferRepository(context);
            Users = new UserRepository(context);
            Equipment = new VehicleEquipmentRepository(context);
            Models = new VehicleModelRepository(context);
        }


        public void Complete()
        {
            _context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
