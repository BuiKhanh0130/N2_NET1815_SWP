using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository iConversationRepository = null;  
        
        public ConversationService()
        {
            if (iConversationRepository == null)
            {
                iConversationRepository = new ConversationRepository();
            }
        }
        public bool AddConversation(Conversation conversation)
        {
            return iConversationRepository.AddConversation(conversation);
        }

        public bool DelConversations(int id)
        {
            return iConversationRepository.DelConversations(id);
        }

        public List<Conversation> GetConversations()
        {
            return iConversationRepository.GetConversations();
        }

        public bool UpdateConversations(Conversation conversation)
        {
            return iConversationRepository.UpdateConversations(conversation);
        }
    }
}
