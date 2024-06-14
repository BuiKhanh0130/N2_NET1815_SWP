using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IConversationAccountService
    {
        public bool AddConversationAccount(ConversationAccount conversationAccount);

        public bool DelConversationAccounts(int id);

        public List<ConversationAccount> GetConversationAccounts(string id);

        public bool UpdateConversationAccounts(ConversationAccount conversationAccount);
    }
}
