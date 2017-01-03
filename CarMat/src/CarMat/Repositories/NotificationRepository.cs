using CarMat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private CMContext _context;

        public NotificationRepository(CMContext context)
        {
            _context = context;
        }

        public List<Notification> GetNotReadNotificationsByUserName(string username)
        {
            return _context.UserNotification
                .Include(un => un.Notification)
                .Include(un => un.User)
                .Where(un => un.User.UserName.Equals(username) && un.IsRead == false)
                .Select(un => un.Notification)
                .ToList();
        }

        public void UpdateUserNotification(UserNotification notification)
        {
            _context.Update(notification);
        }

        public void AddNewNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
        }

        public void AddNewNotificationToUser(UserNotification notification, CMUser user)
        {
            _context.UserNotification.Add(notification);
            user.Notifications.Add(notification);
        }
    }
}
