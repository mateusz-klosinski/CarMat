using CarMat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public class WatchRepository : IWatchRepository
    {
        private CMContext _context;

        public WatchRepository(CMContext context)
        {
            _context = context;
        }

        public void AddNewWatch(Offer offer, CMUser user)
        {
            var watch = new Watch
            {
                Watcher = user,
                WatchedOffer = offer
            };

            user.Watches.Add(watch);
            offer.Watches.Add(watch);
            _context.Watches.Add(watch);
        }

        public void RemoveWatch(Offer offer, CMUser user)
        {
            var watch = _context.Watches
                .Where(w => w.WatcherId == user.Id &&
                w.WatchedOfferId == offer.Id)
                .FirstOrDefault();

            _context.Watches.Remove(watch);
            user.Watches.Remove(watch);
            offer.Watches.Remove(watch);            
        }
    }
}
