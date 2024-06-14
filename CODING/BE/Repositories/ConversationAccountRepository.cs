using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ConversationAccountRepository : IConversationAccountRepository
    {
        private readonly ConversationAccountDAO conversationAccountDAO = null;

        public ConversationAccountRepository()
        {
            if (conversationAccountDAO == null)
            {
                conversationAccountDAO = new ConversationAccountDAO();
            }
        }
        public bool AddConversationAccount(ConversationAccount conversationAccount)
        {
            return conversationAccountDAO.AddConversationAccount(conversationAccount);
        }

        public bool DelConversationAccounts(int id)
        {
            return conversationAccountDAO.DelConversationAccounts(id);
        }

        public List<ConversationAccount> GetConversationAccounts(string id)
        {
            return conversationAccountDAO.GetConversationAccounts(id);
        }

        public bool UpdateConversationAccounts(ConversationAccount conversationAccount)
        {
            return conversationAccountDAO.UpdateConversationAccounts(conversationAccount);
        }
    }
}
