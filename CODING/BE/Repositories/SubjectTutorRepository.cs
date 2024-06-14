using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SubjectTutorRepository : ISubjectTutorRepository
    {
        private readonly SubjectTutorTutorDAO subjectTutorDAO = null;

        public SubjectTutorRepository()
        {
            if (subjectTutorDAO == null)
            {
                subjectTutorDAO= new SubjectTutorTutorDAO();
            }
        }

        public bool AddSubjectTutor(SubjectTutor subjectTutor)
        {
            return subjectTutorDAO.AddSubjectTutor(subjectTutor);
        }

        public bool DelSubjectTutors(int id)
        {
            return subjectTutorDAO.DelSubjectTutors(id);
        }

        public List<SubjectTutor> GetAllSubjectTutors()
        {
            return subjectTutorDAO.GetAllSubjectTutors();
        }

        public List<SubjectTutor> GetSubjectTutors(string id)
        {
            return subjectTutorDAO.GetSubjectTutors(id);
        }

        public bool UpdateSubjectTutors(SubjectTutor subjectTutor)
        {
            return subjectTutorDAO.UpdateSubjectTutors(subjectTutor);
        }
    }
}
