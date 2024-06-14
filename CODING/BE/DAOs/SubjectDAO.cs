using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class SubjectDAO
    {
        private readonly DbContext dbContext = null;
        public SubjectDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddSubject(Subject subject)
        {
            dbContext.Subjects.Add(subject);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelSubjects(int id)
        {
            Subject subject = dbContext.Subjects.Find(id);
            dbContext.Subjects.Remove(subject);
            dbContext.SaveChanges();
            return true;
        }

        public List<Subject> GetSubjects()
        {
            return dbContext.Subjects.OrderByDescending(x => x.SubjectId).ToList();
        }

        public bool UpdateSubjects(Subject subject)
        {
            dbContext.Subjects.Update(subject);
            dbContext.SaveChanges();
            return true;
        }
    }
}
