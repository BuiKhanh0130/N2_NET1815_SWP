using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class TransactionDAO
    {
        private readonly DbContext dbContext = null;
        public TransactionDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddTransaction(Transaction transaction)
        {
            dbContext.Transactions.Add(transaction);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelTransactions(int id)
        {
            Transaction transaction = dbContext.Transactions.Find(id);
            dbContext.Transactions.Remove(transaction);
            dbContext.SaveChanges();
            return true;
        }

        public List<Transaction> GetTransactions()
        {
            return dbContext.Transactions.OrderByDescending(x => x.TransactionId).ToList();
        }

        public bool UpdateTransactions(Transaction transaction)
        {
            dbContext.Transactions.Update(transaction);
            dbContext.SaveChanges();
            return true;
        }
    }
}
