using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISubjectService
    {
        public bool AddSubject(Subject subject);

        public bool DelSubjects(int id);

        public List<Subject> GetSubjects();

        public bool UpdateSubjects(Subject subject);
    }
}
