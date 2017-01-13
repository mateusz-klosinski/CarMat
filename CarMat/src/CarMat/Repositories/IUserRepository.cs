using CarMat.Models;
using CarMat.ViewModels;
using System.Collections.Generic;

namespace CarMat.Repositories
{
    public interface IUserRepository
    {
        CMUser GetUserIncludingHisOffers(string username);
        CMUser GetUserByName(string username);
        List<UserStatsViewModel> GetUsersOffersCount();
    }
}