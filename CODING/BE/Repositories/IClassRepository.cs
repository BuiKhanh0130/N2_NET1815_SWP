using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IClassRepository
    {
        public bool AddClass(Class @class);

        public bool DelClasses(int id);

        public List<Class> GetClasses();

        public bool UpdateClasses(Class @class);
    }
}
