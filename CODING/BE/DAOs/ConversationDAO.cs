using BusinessObjects;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class ConversationDAO
    {
        private readonly DbContext dbContext = null;
        public ConversationDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddConversation(Conversation conversation)
        {
            dbContext.Conversations.Add(conversation);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelConversations(int id)
        {
            Conversation conversation = dbContext.Conversations.Find(id);
            dbContext.Conversations.Remove(conversation);
            dbContext.SaveChanges();
            return true;
        }

        public List<Conversation> GetConversations()
        {
            return dbContext.Conversations.OrderByDescending(x => x.ConversationId).ToList();
        }

        public bool UpdateConversations(Conversation conversation)
        {
            dbContext.Conversations.Update(conversation);
            dbContext.SaveChanges();
            return true;
        }
    }
}
