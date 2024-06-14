using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleDAO roleDAO = null;

        public RoleRepository()
        {
            if (roleDAO == null)
            {
                roleDAO = new RoleDAO();
            }
        }

        public bool AddRole(Role role)
        {
            return roleDAO.AddRole(role);
        }

        public bool DelRoles(int id)
        {
            return roleDAO.DelRoles(id);
        }

        public List<Role> GetRoles()
        {
            return roleDAO.GetRoles();
        }

        public bool UpdateAccounts(Role role)
        {
            return roleDAO.UpdateRoles(role);
        }
    }
}
