using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRoleService
    {
        public bool AddRole(Role role);

        public bool DelRoles(int id);

        public List<Role> GetRoles();

        public bool UpdateAccounts(Role role);
    }
}
