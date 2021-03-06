﻿using System.Collections.Generic;
using CarMat.Models;

namespace CarMat.Repositories
{
    public interface INotificationRepository
    {
        void AddNewNotification(Notification notification);
        void AddNewNotificationToUser(UserNotification notification, CMUser user);
        List<Notification> GetNotReadNotificationsByUserName(string username);
        void UpdateUserNotification(UserNotification notification);
    }
}