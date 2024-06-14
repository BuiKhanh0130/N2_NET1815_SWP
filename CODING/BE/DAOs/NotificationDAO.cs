using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class NotificationDAO
    {
        private readonly DbContext dbContext = null;
        public NotificationDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddNotification(Notification notification)
        {
            dbContext.Notifications.Add(notification);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelNotifications(int id)
        {
            Notification notification = dbContext.Notifications.Find(id);
            dbContext.Notifications.Remove(notification);
            dbContext.SaveChanges();
            return true;
        }

        public List<Notification> GetNotifications()
        {
            return dbContext.Notifications.OrderByDescending(x => x.NotificationId).ToList();
        }

        public bool UpdateNotifications(Notification notification)
        {
            dbContext.Notifications.Update(notification);
            dbContext.SaveChanges();
            return true;
        }
    }
}
