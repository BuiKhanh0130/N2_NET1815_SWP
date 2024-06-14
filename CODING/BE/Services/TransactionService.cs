using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository iTransactionRepository = null;

        public TransactionService()
        {
            if (iTransactionRepository == null)
            {
                iTransactionRepository = new TransactionRepository();
            }
        }

        public bool AddTransaction(Transaction transaction)
        {
            return iTransactionRepository.AddTransaction(transaction);
        }

        public bool DelTransactions(int id)
        {
            return iTransactionRepository.DelTransactions(id);
        }

        public List<Transaction> GetTransactions()
        {
            return iTransactionRepository.GetTransactions();
        }

        public bool UpdateTransactions(Transaction transaction)
        {
            return iTransactionRepository.UpdateTransactions(transaction);
        }
    }
}
