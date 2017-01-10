using CarMat.Models;
using CarMat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Services
{
    public class NotificationService
    {
        private IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<Notification> GetNotReadNotifications(string username)
        {
           return _unitOfWork.Notifications.GetNotReadNotificationsByUserName(username);
        }




        public void CreateNotificationsForAllWatchers(int offerId, NotificationType type)
        {
            var offer = _unitOfWork.Offers.GetOfferById(offerId);

            Notification notification = createNotificationForType(offer, type);

            _unitOfWork.Notifications.AddNewNotification(notification);

            foreach (Watch watch in offer.Watches)
            {
                UserNotification userNotification = new UserNotification
                {
                    User = watch.Watcher,
                    Notification = notification,
                    IsRead = false,
                };

                _unitOfWork.Notifications.AddNewNotificationToUser(userNotification, watch.Watcher);
            }

            _unitOfWork.Complete();
        }

        private Notification createNotificationForType(Offer offer, NotificationType type)
        {
            Notification notification = new Notification
            {
                NotificationType = type,
                NotificationTime = DateTime.Now,
                Description = $"Oferta użytkownika {offer.User.UserName} dotycząca pojazdu {offer.Vehicle.Model.Brand.Name} {offer.Vehicle.Model.Name}",
            };

            if (type == NotificationType.OfferUpdated)
            {
                notification.Description += " została zaktualizowana. Zajrzyj zobaczyć co się zmieniło.";
            }
            else
            {
                notification.Description += " została zakończona.";
            }


            return notification;
        }

        public void ReadUserNotifications(string username)
        {
            var user = _unitOfWork.Users.GetUserByName(username);

            foreach (var notification in user.Notifications)
            {
                notification.IsRead = true;
                _unitOfWork.Notifications.UpdateUserNotification(notification);
            }


            _unitOfWork.Complete();
        }
    }
}
