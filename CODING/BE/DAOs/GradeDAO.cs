using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class GradeDAO
    {
        private readonly DbContext dbContext = null;
        public GradeDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddGrade(Grade grade)
        {
            dbContext.Grades.Add(grade);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelGrades(int id)
        {
            Grade grade = dbContext.Grades.Find(id);
            dbContext.Grades.Remove(grade);
            dbContext.SaveChanges();
            return true;
        }

        public List<Grade> GetGrades()
        {
            return dbContext.Grades.OrderByDescending(x => x.GradeId).ToList();
        }

        public bool UpdateGrades(Grade grade)
        {
            dbContext.Grades.Update(grade);
            dbContext.SaveChanges();
            return true;
        }
    }
}
