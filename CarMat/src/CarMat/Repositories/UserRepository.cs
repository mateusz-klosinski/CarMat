using CarMat.Models;
using CarMat.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CMContext _context;

        public UserRepository(CMContext context)
        {
            _context = context;
        }

        public CMUser GetUserByName(string username)
        {
            return _context.Users
                .Include(o => o.Watches)
                .Include(o => o.Notifications)
                .Where(u => u.UserName.Equals(username))
                .FirstOrDefault();
        }

        public CMUser GetUserIncludingHisOffers(string username)
        {
            return _context.Users
                    .Include(u => u.Offers)
                    .Include(u => u.Watches)
                    .Where(u => u.UserName
                    .Equals(username))
                    .FirstOrDefault();
        }


        public List<UserStatsViewModel> GetUsersOffersCount()
        {
            return _context.Users
                .Include(u => u.Offers)
                .Select(u => new UserStatsViewModel
                {
                    UserName = u.UserName,
                    OfferCount = u.Offers.Count(),
                })
                .OrderByDescending(u => u.OfferCount)
                .ThenBy(u => u.UserName)
                .ToList();
        }
    }
}
