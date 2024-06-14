using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationDAO notificationDAO = null;

        public NotificationRepository()
        {
            if (notificationDAO == null)
            {
                notificationDAO = new NotificationDAO();
            }
        }

        public bool AddNotification(Notification notification)
        {
            return notificationDAO.AddNotification(notification);
        }

        public bool DelNotifications(int id)
        {
            return notificationDAO.DelNotifications(id);
        }

        public List<Notification> GetNotifications()
        {
            return notificationDAO.GetNotifications();
        }

        public bool UpdateNotifications(Notification notification)
        {
            return notificationDAO.UpdateNotifications(notification);
        }
    }
}
