using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoleRepository
    {
        public bool AddRole(Role role);

        public bool DelRoles(int id);

        public List<Role> GetRoles();

        public bool UpdateAccounts(Role role);
    }
}
