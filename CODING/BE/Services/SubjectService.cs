using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository iSubjectRepository = null;

        public SubjectService()
        {
            if (iSubjectRepository == null)
            {
                iSubjectRepository = new SubjectRepository();
            }
        }

        public bool AddSubject(Subject subject)
        {
            return iSubjectRepository.AddSubject(subject);
        }

        public bool DelSubjects(int id)
        {
            return iSubjectRepository.DelSubjects(id);
        }

        public List<Subject> GetSubjects()
        {
            return iSubjectRepository.GetSubjects();
        }

        public bool UpdateSubjects(Subject subject)
        {
            return iSubjectRepository.UpdateSubjects(subject);
        }
    }
}
