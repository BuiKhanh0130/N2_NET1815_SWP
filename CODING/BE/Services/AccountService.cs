using BusinessObjects;
using BusinessObjects.Models;
using DAOs;
using Microsoft.AspNetCore.Identity;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository iAccountRepository;


        public AccountService(IAccountRepository _iAccountRepository)
        {
            iAccountRepository = _iAccountRepository;
        }

        public bool AddAccount(Account account)
        {
            return iAccountRepository.AddAccount(account);
        }

        public bool DelAccounts(int id)
        {
            return iAccountRepository.DelAccounts(id);
        }

        public List<Account> GetAccounts()
        {
            return iAccountRepository.GetAccounts();
        }

        public async Task<Account> GetAccountById(string id)
        {
            return await iAccountRepository.GetAccountById(id);
        }

        public Task<IList<string>> GetRolesAsync(Account user)
        {
            return iAccountRepository.GetRolesAsync(user);
        }

        public Task<Account> SignInAsync(UserSignIn model)
        {
            return iAccountRepository.SignInAsync(model);
        }

        public async Task<IdentityResult> SignUpAsync(AccountDTO model)
        {
            return await iAccountRepository.SignUpAsync(model);
        }

        public bool UpdateAccounts(Account account)
        {
            return iAccountRepository.UpdateAccounts(account);
        }
    }
}
