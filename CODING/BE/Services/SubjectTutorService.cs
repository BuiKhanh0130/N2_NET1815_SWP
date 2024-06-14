using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SubjectTutorService : ISubjectTutorService
    {
        private readonly ISubjectTutorRepository iSubjectTutorRepository = null;

        public SubjectTutorService()
        {
            if (iSubjectTutorRepository == null)
            {
                iSubjectTutorRepository = new SubjectTutorRepository();
            }
        }
        public bool AddSubjectTutor(SubjectTutor subjectTutor)
        {
            return iSubjectTutorRepository.AddSubjectTutor(subjectTutor);
        }

        public bool DelSubjectTutors(int id)
        {
            return iSubjectTutorRepository.DelSubjectTutors(id);
        }

        public List<SubjectTutor> GetAllSubjectTutors()
        {
            return iSubjectTutorRepository.GetAllSubjectTutors();
        }

        public List<SubjectTutor> GetSubjectTutors(string id)
        {
            return iSubjectTutorRepository.GetSubjectTutors(id);
        }

        public bool UpdateSubjectTutors(SubjectTutor subjectTutor)
        {
            return iSubjectTutorRepository.UpdateSubjectTutors(subjectTutor);
        }
    }
}
