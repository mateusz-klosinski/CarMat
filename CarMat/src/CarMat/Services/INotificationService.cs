using CarMat.Models;
using System.Collections.Generic;

namespace CarMat.Services
{
    public interface INotificationService
    {
        void CreateNotificationsForAllWatchers(int offerId, NotificationType type);
        List<Notification> GetNotifications(string username);
    }
}