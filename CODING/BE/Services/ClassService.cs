using BusinessObjects;
using DAOs;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository iClassRepository = null;

        public ClassService()
        {
            if (iClassRepository == null)
            {
                iClassRepository = new ClassRepository();
            }
        }

        public bool AddClass(Class @class)
        {
            return iClassRepository.AddClass(@class);
        }

        public bool DelClasses(int id)
        {
            return iClassRepository.DelClasses(id);
        }

        public List<Class> GetClasses()
        {
            return iClassRepository.GetClasses();
        }

        public bool UpdateClasses(Class @class)
        {
            return iClassRepository.UpdateClasses(@class);
        }
    }
}
