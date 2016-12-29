using CarMat.Models;
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

        public CMUser GetUserIncludingHisOffers(string username)
        {
            return _context.Users
                    .Include(u => u.Offers)
                    .Where(u => u.UserName
                    .Equals(username))
                    .FirstOrDefault();
        }
    }
}
