using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class MessageDAO
    {
        private readonly DbContext dbContext = null;
        public MessageDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddMessage(Message message)
        {
            dbContext.Messages.Add(message);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelMessages(int id)
        {
            Message message = dbContext.Messages.Find(id);
            dbContext.Messages.Remove(message);
            dbContext.SaveChanges();
            return true;
        }

        public List<Message> GetMessages()
        {
            return dbContext.Messages.OrderByDescending(x => x.MessageId).ToList();
        }

        public bool UpdateMessages(Message message)
        {
            dbContext.Messages.Update(message);
            dbContext.SaveChanges();
            return true;
        }
    }
}
