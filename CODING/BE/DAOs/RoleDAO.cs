using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class RoleDAO
    {
        private readonly DbContext dbContext = null;

        public RoleDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }
        public bool AddRole(Role role)
        {
            dbContext.Roles.Add(role);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelRoles(int id)
        {
            Role role = dbContext.Roles.Find(id);
            dbContext.Roles.Remove(role);
            dbContext.SaveChanges();
            return true;
        }

        public List<Role> GetRoles()
        {
            return dbContext.Roles.OrderByDescending(x => x.RoleId).ToList();
        }

        public bool UpdateRoles(Role role)
        {
            dbContext.Roles.Update(role);
            dbContext.SaveChanges();
            return true;
        }
    }
}
