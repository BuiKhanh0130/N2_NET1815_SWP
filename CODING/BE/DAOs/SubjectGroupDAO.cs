using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class SubjectGroupDAO
    {
        private readonly DbContext dbContext = null;
        public SubjectGroupDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddSubjectGroup(SubjectGroup subjectGroup)
        {
            dbContext.SubjectGroups.Add(subjectGroup);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelSubjectGroups(int id)
        {
            SubjectGroup subjectGroup = dbContext.SubjectGroups.Find(id);
            dbContext.SubjectGroups.Remove(subjectGroup);
            dbContext.SaveChanges();
            return true;
        }

        public List<SubjectGroup> GetSubjectGroups()
        {
            return dbContext.SubjectGroups.OrderByDescending(x => x.SubjectGroupId).ToList();
        }

        public bool UpdateSubjectGroups(SubjectGroup subjectGroup)
        {
            dbContext.SubjectGroups.Update(subjectGroup);
            dbContext.SaveChanges();
            return true;
        }
    }
}
