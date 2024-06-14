using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository iNotificationRepository = null;

        public NotificationService()
        {
            if (iNotificationRepository == null)
            {
                iNotificationRepository = new NotificationRepository();
            }
        }

        public bool AddNotification(Notification notification)
        {
            return iNotificationRepository.AddNotification(notification);
        }

        public bool DelNotifications(int id)
        {
            return iNotificationRepository.DelNotifications(id);
        }

        public List<Notification> GetNotifications()
        {
            return iNotificationRepository.GetNotifications();
        }

        public bool UpdateNotifications(Notification notification)
        {
            return iNotificationRepository.UpdateNotifications(notification);
        }
    }
}
