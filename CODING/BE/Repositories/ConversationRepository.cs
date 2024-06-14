using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly ConversationDAO conversationDAO = null;

        public ConversationRepository()
        {
            if (conversationDAO == null)
            {
                conversationDAO = new ConversationDAO();
            }
        }

        public bool AddConversation(Conversation conversation)
        {
            return conversationDAO.AddConversation(conversation);
        }

        public bool DelConversations(int id)
        {
            return conversationDAO.DelConversations(id);
        }

        public List<Conversation> GetConversations()
        {
            return conversationDAO.GetConversations();
        }

        public bool UpdateConversations(Conversation conversation)
        {
            return conversationDAO.UpdateConversations(conversation);
        }
    }
}
