using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageDAO messageDAO = null;

        public MessageRepository()
        {
            if (messageDAO == null)
            {
                messageDAO = new MessageDAO();
            }
        }

        public bool AddMessage(Message message)
        {
            return messageDAO.AddMessage(message);
        }

        public bool DelMessages(int id)
        {
            return messageDAO.DelMessages(id);
        }

        public List<Message> GetMessages()
        {
            return messageDAO.GetMessages();
        }

        public bool UpdateMessages(Message message)
        {
            return messageDAO.UpdateMessages(message);
        }
    }
}
