using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public NotificationType NotificationType { get; set; }

        public DateTime NotificationTime { get; set; }

        public string Description { get; set; }

        public ICollection<UserNotification> Users { get; set; }
    }
}
