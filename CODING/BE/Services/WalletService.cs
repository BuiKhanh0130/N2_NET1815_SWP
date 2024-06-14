using BusinessObjects;
using DAOs;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository iWalletRepository = null;

        public WalletService()
        {
            if (iWalletRepository == null)
            {
                iWalletRepository = new WalletRepository();
            }
        }

        public bool AddWallet(Wallet wallet)
        {
            return iWalletRepository.AddWallet(wallet);
        }

        public bool DelWallets(int id)
        {
            return iWalletRepository.DelWallets(id);
        }

        public List<Wallet> GetWallets()
        {
            return iWalletRepository.GetWallets();
        }

        public bool UpdateWallets(Wallet wallet)
        {
            return iWalletRepository.UpdateWallets(wallet);
        }
    }
}

