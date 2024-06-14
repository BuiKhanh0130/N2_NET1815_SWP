using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SubjectDAO subjectDAO = null;

        public SubjectRepository()
        {
            if (subjectDAO == null)
            {
                subjectDAO = new SubjectDAO();
            }
        }

        public bool AddSubject(Subject subject)
        {
            return subjectDAO.AddSubject(subject);
        }

        public bool DelSubjects(int id)
        {
            return subjectDAO.DelSubjects(id);
        }

        public List<Subject> GetSubjects()
        {
            return subjectDAO.GetSubjects();
        }

        public bool UpdateSubjects(Subject subject)
        {
            return subjectDAO.UpdateSubjects(subject);
        }
    }
}
