using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IConversationService
    {
        public bool AddConversation(Conversation conversation);

        public bool DelConversations(int id);

        public List<Conversation> GetConversations();

        public bool UpdateConversations(Conversation conversation);
    }
}
