using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITransactionService
    {
        public bool AddTransaction(Transaction transaction);

        public bool DelTransactions(int id);

        public List<Transaction> GetTransactions();

        public bool UpdateTransactions(Transaction transaction);
    }
}
