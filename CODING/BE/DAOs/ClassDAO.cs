using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class ClassDAO
    {
        private readonly DbContext dbContext = null;

        public ClassDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }
        public bool AddClass(Class @class)
        {
            dbContext.Classes.Add(@class);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelClasses(int id)
        {
            Class @class = dbContext.Classes.Find(id);
            dbContext.Classes.Remove(@class);
            dbContext.SaveChanges();
            return true;
        }

        public List<Class> GetClasses()
        {
            return dbContext.Classes.OrderByDescending(x => x.ClassId).ToList();
        }

        public bool UpdateClasses(Class @class)
        {
            dbContext.Classes.Update(@class);
            dbContext.SaveChanges();
            return true;
        }
    }
}
