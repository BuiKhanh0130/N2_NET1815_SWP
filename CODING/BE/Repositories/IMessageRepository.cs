using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IMessageRepository
    {
        public bool AddMessage(Message message);

        public bool DelMessages(int id);

        public List<Message> GetMessages();

        public bool UpdateMessages(Message message);
    }
}
