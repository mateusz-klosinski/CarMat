using CarMat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CMContext _context;

        public IOfferRepository Offers { get; private set; }
        public IUserRepository Users { get; private set; }
        public IVehicleEquipmentRepository Equipment { get; private set; }
        public IVehicleModelRepository Models { get; private set; }
        public IDemographicsRepository Demographics { get; private set; }

        public UnitOfWork(CMContext context)
        {
            _context = context;
            Offers = new OfferRepository(context);
            Users = new UserRepository(context);
            Equipment = new VehicleEquipmentRepository(context);
            Models = new VehicleModelRepository(context);
            Demographics = new DemographicsRepository(context);
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
