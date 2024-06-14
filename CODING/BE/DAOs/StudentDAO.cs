using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class StudentDAO
    {
        private readonly DbContext dbContext = null;
        public StudentDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddStudent(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelStudents(int id)
        {
            Student student = dbContext.Students.Find(id);
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return true;
        }

        public List<Student> GetStudents()
        {
            return dbContext.Students.OrderByDescending(x => x.StudentId).ToList();
        }

        public bool UpdateStudents(Student student)
        {
            dbContext.Students.Update(student);
            dbContext.SaveChanges();
            return true;
        }
    }
}
