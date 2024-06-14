using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IWalletService
    {
        public bool AddWallet(Wallet wallet);

        public bool DelWallets(int id);

        public List<Wallet> GetWallets();

        public bool UpdateWallets(Wallet wallet);
    }
}
