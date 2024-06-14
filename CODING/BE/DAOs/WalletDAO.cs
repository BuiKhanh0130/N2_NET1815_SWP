using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class WalletDAO
    {
        private readonly DbContext dbContext = null;
        public WalletDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddWallet(Wallet wallet)
        {
            dbContext.Wallets.Add(wallet);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelWallets(int id)
        {
            Wallet wallet = dbContext.Wallets.Find(id);
            dbContext.Wallets.Remove(wallet);
            dbContext.SaveChanges();
            return true;
        }

        public List<Wallet> GetWallets()
        {
            return dbContext.Wallets.OrderByDescending(x => x.WalletId).ToList();
        }

        public bool UpdateWallets(Wallet wallet)
        {
            dbContext.Wallets.Update(wallet);
            dbContext.SaveChanges();
            return true;
        }
    }
}
