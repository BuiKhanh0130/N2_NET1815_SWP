using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConversationAccountService : IConversationAccountService
    {
        private readonly IConversationAccountRepository iConversationAccountRepository = null;

        public ConversationAccountService()
        {
            if (iConversationAccountRepository == null)
            {
                iConversationAccountRepository = new ConversationAccountRepository();
            }
        }

        public bool AddConversationAccount(ConversationAccount conversationAccount)
        {
            return iConversationAccountRepository.AddConversationAccount(conversationAccount);
        }

        public bool DelConversationAccounts(int id)
        {
            return iConversationAccountRepository.DelConversationAccounts(id);
        }

        public List<ConversationAccount> GetConversationAccounts(string id)
        {
            return iConversationAccountRepository.GetConversationAccounts(id);
        }

        public bool UpdateConversationAccounts(ConversationAccount conversationAccount)
        {
            return iConversationAccountRepository.UpdateConversationAccounts(conversationAccount);
        }
    }
}
