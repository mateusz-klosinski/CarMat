using CarMat.Models;

namespace CarMat.Services
{
    public interface INotificationService
    {
        void CreateNotificationsForAllWatchers(int offerId, NotificationType type);
    }
}