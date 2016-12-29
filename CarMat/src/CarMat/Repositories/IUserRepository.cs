using CarMat.Models;

namespace CarMat.Repositories
{
    public interface IUserRepository
    {
        CMUser GetUserIncludingHisOffers(string username);
    }
}