using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITransactionRepository
    {
        public bool AddTransaction(Transaction transaction);

        public bool DelTransactions(int id);

        public List<Transaction> GetTransactions();

        public bool UpdateTransactions(Transaction transaction);
    }
}
