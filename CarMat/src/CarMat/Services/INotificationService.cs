using CarMat.Models;
using System.Collections.Generic;

namespace CarMat.Services
{
    public interface INotificationService
    {
        void CreateNotificationsForAllWatchers(int offerId, NotificationType type);
        List<Notification> GetNotReadNotifications(string username);
        void ReadUserNotifications(string username);
    }
}