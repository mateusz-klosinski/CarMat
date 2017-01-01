namespace CarMat.Services
{
    public interface IWatchService
    {
        void AddNewWatch(int offerId, string username);
        void RemoveWatch(int offerId, string username);
    }
}