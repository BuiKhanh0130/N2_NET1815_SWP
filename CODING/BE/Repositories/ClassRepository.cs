using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly ClassDAO classDAO = null;

        public ClassRepository()
        {
            if (classDAO == null)
            {
                classDAO = new ClassDAO();
            }
        }

        public bool AddClass(Class @class)
        {
            return classDAO.AddClass(@class);
        }

        public bool DelClasses(int id)
        {
            return classDAO.DelClasses(id);
        }

        public List<Class> GetClasses()
        {
            return classDAO.GetClasses();
        }

        public bool UpdateClasses(Class @class)
        {
            return classDAO.UpdateClasses(@class);
        }
    }
}
