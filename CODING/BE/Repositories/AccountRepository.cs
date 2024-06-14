using AutoMapper;
using BusinessObjects;
using BusinessObjects.Constrant;
using BusinessObjects.Models;
using DAOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDAO accountDAO = null;
        private UserManager<Account> _userManager;
        private SignInManager<Account> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private IMapper _mapper;

        public AccountRepository()
        {
            if (accountDAO == null)
            {
                accountDAO = new AccountDAO();
            }
        }

        public AccountRepository(UserManager<Account> userManager,
            SignInManager<Account> signInManager, IConfiguration configuration,
            RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            if (accountDAO == null)
            {
                accountDAO = new AccountDAO();
            }
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public bool AddAccount(Account account)
        {
            return accountDAO.AddAccount(account);
        }

        public bool DelAccounts(int id)
        {
            return accountDAO.DelAccounts(id);
        }

        public List<Account> GetAccounts()
        {
            return accountDAO.GetAccounts();
        }

        public bool UpdateAccounts(Account account)
        {
            return accountDAO.UpdateAccounts(account);
        }

        public async Task<IList<string>> GetRolesAsync(Account user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<Account> SignInAsync(UserSignIn model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                return user;
            }
            return null;
        }
        public async Task<IdentityResult> SignUpAsync(AccountDTO model)
        {
            var isDupplicate = await _userManager.FindByEmailAsync(model.Email);
            if (isDupplicate != null)
            {
                return null;
            }
            var user = _mapper.Map<Account>(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // init role in the system
                if (!await _roleManager.RoleExistsAsync(AppRole.Tutor))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Tutor));
                }

                if (!await _roleManager.RoleExistsAsync(AppRole.Student))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Student));
                }

                if (!await _roleManager.RoleExistsAsync(AppRole.SystemHandler))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.SystemHandler));
                }

                if (!await _roleManager.RoleExistsAsync(AppRole.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Admin));
                }

                if (!await _roleManager.RoleExistsAsync(AppRole.Moderator))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Moderator));
                }

                // role init is student
                if (model.isAdmin)
                {
                    await _userManager.AddToRoleAsync(user, AppRole.Admin);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, AppRole.Student);
                }

                //await _userManager.AddToRoleAsync(user, AppRole.Customer);
            }
            return result;

        }

        public async Task<IQueryable<UserRolesVM>> GetAll()
        {
            var listUserRolesVM = new List<UserRolesVM>();
            var listUser = accountDAO.GetAccounts().ToList();
            foreach (var user in listUser.ToList())
            {
                var userRoles = (await GetRolesAsync(user));
                if (userRoles.Contains(AppRole.Admin))
                {
                    listUser.Remove(user);
                }
                else
                {
                    var userRolesVM = _mapper.Map<UserRolesVM>(user);
                    userRolesVM.RolesName = userRoles.ToList();
                    listUserRolesVM.Add(userRolesVM);
                }
            }
            return listUserRolesVM.AsQueryable();
        }

        public async Task<Account> GetAccountById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}
