using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISubjectRepository
    {
        public bool AddSubject(Subject subject);

        public bool DelSubjects(int id);

        public List<Subject> GetSubjects();

        public bool UpdateSubjects(Subject subject);
    }
}
