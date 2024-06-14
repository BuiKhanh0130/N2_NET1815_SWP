using BusinessObjects;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Identity;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAccountService
    {
        public bool AddAccount(Account account);

        public bool DelAccounts(int id);

        public List<Account> GetAccounts();

        public Task<Account> GetAccountById(string id);
        public bool UpdateAccounts(Account account);

        Task<IdentityResult> SignUpAsync(AccountDTO model);
        Task<Account> SignInAsync(UserSignIn model);
        Task<IList<String>> GetRolesAsync(Account user);
    }
}
