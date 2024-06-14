using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository iMessageRepository = null;

        public MessageService()
        {
            if (iMessageRepository == null)
            {
                iMessageRepository = new MessageRepository();
            }
        }

        public bool AddMessage(Message message)
        {
            return iMessageRepository.AddMessage(message);
        }

        public bool DelMessages(int id)
        {
            return iMessageRepository.DelMessages(id);
        }

        public List<Message> GetMessages()
        {
            return iMessageRepository.GetMessages();
        }

        public bool UpdateMessages(Message message)
        {
            return iMessageRepository.UpdateMessages(message);
        }
    }
}
