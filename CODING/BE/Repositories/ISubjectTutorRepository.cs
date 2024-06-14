using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISubjectTutorRepository
    {
        public bool AddSubjectTutor(SubjectTutor subjectTutor);

        public bool DelSubjectTutors(int id);

        public List<SubjectTutor> GetSubjectTutors(string id);

        public List<SubjectTutor> GetAllSubjectTutors();

        public bool UpdateSubjectTutors(SubjectTutor subjectTutor);
    }
}
