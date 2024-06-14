using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface INotificationRepository
    {
        public bool AddNotification(Notification notification);

        public bool DelNotifications(int id);

        public List<Notification> GetNotifications();

        public bool UpdateNotifications(Notification notification);
    }
}
