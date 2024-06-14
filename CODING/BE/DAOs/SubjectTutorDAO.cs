using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class SubjectTutorTutorDAO
    {
        private readonly DbContext dbContext = null;
        public SubjectTutorTutorDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddSubjectTutor(SubjectTutor subjectTutor)
        {
            dbContext.SubjectTutors.Add(subjectTutor);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelSubjectTutors(int id)
        {
            SubjectTutor subjectTutor = dbContext.SubjectTutors.Find(id);
            dbContext.SubjectTutors.Remove(subjectTutor);
            dbContext.SaveChanges();
            return true;
        }

        public List<SubjectTutor> GetSubjectTutors(string id)
        {
            return dbContext.SubjectTutors.Where(x => x.TutorId == id).ToList();
        }

        public List<SubjectTutor> GetAllSubjectTutors()
        {
            return dbContext.SubjectTutors.ToList();
        }

        public bool UpdateSubjectTutors(SubjectTutor subjectTutor)
        {
            dbContext.SubjectTutors.Update(subjectTutor);
            dbContext.SaveChanges();
            return true;
        }
    }
}
