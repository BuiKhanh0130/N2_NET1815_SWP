using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository iRoleRepository = null;

        public RoleService()
        {
            if (iRoleRepository == null)
            {
                iRoleRepository = new RoleRepository();
            }
        }
        public bool AddRole(Role role)
        {
            return iRoleRepository.AddRole(role);
        }

        public bool DelRoles(int id)
        {
            return iRoleRepository.DelRoles(id);
        }

        public List<Role> GetRoles()
        {
            return iRoleRepository.GetRoles();
        }

        public bool UpdateAccounts(Role role)
        {
            return iRoleRepository.UpdateAccounts(role);
        }
    }
}
