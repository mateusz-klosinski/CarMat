using CarMat.Models;

namespace CarMat.Repositories
{
    public interface IWatchRepository
    {
        void AddNewWatch(Offer offer, CMUser user);
        void RemoveWatch(Offer offer, CMUser user);
    }
}