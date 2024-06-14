using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDAO transactionDAO = null;

        public TransactionRepository()
        {
            if (transactionDAO == null)
            {
                transactionDAO = new TransactionDAO();
            }
        }

        public bool AddTransaction(Transaction transaction)
        {
            return transactionDAO.AddTransaction(transaction);
        }

        public bool DelTransactions(int id)
        {
            return transactionDAO.DelTransactions(id);
        }

        public List<Transaction> GetTransactions()
        {
            return transactionDAO.GetTransactions();
        }

        public bool UpdateTransactions(Transaction transaction)
        {
            return transactionDAO.UpdateTransactions(transaction);
        }
    }
}
