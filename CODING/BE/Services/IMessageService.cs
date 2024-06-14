using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMessageService
    {
        public bool AddMessage(Message message);

        public bool DelMessages(int id);

        public List<Message> GetMessages();

        public bool UpdateMessages(Message message);
    }
}
