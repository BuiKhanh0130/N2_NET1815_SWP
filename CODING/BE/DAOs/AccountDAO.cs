using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class AccountDAO
    {
        private readonly DbContext dbContext = null;

        public AccountDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddAccount(Account account)
        {
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelAccounts(int id)
        {
            Account account = dbContext.Accounts.Find(id);
            dbContext.Accounts.Remove(account);
            dbContext.SaveChanges();
            return true;
        }

        public List<Account> GetAccounts()
        {
            return dbContext.Accounts.OrderByDescending(x => x.Email).ToList();
        }

        public bool UpdateAccounts(Account account)
        {
            dbContext.Accounts.Update(account);
            dbContext.SaveChanges();
            return true;
        }
    }
}
