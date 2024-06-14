using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class ConversationAccountDAO
    {
        private readonly DbContext dbContext = null;
        public ConversationAccountDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddConversationAccount(ConversationAccount conversationAccount)
        {
            dbContext.ConversationAccounts.Add(conversationAccount);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelConversationAccounts(int id)
        {
            ConversationAccount conversationAccount = dbContext.ConversationAccounts.Find(id);
            dbContext.ConversationAccounts.Remove(conversationAccount);
            dbContext.SaveChanges();
            return true;
        }

        public List<ConversationAccount> GetConversationAccounts(string id)
        {
            return dbContext.ConversationAccounts.Where(x => x.ConversationId == id).ToList();
        }

        public bool UpdateConversationAccounts(ConversationAccount conversationAccount)
        {
            dbContext.ConversationAccounts.Update(conversationAccount);
            dbContext.SaveChanges();
            return true;
        }
    }
}
