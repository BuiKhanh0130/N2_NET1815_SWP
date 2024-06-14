using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletDAO walletDAO = null;

        public WalletRepository()
        {
            if (walletDAO == null)
            {
                walletDAO = new WalletDAO();
            }
        }

        public bool AddWallet(Wallet wallet)
        {
            return walletDAO.AddWallet(wallet);
        }

        public bool DelWallets(int id)
        {
            return walletDAO.DelWallets(id);
        }

        public List<Wallet> GetWallets()
        {
            return walletDAO.GetWallets();
        }

        public bool UpdateWallets(Wallet wallet)
        {
            return walletDAO.UpdateWallets(wallet);
        }
    }
}
