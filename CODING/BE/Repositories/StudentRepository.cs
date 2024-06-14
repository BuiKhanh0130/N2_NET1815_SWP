using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDAO studentDAO = null;

        public StudentRepository()
        {
            if (studentDAO == null)
            {
                studentDAO = new StudentDAO();
            }
        }

        public bool AddStudent(Student student)
        {
            return studentDAO.AddStudent(student);
        }

        public bool DelStudents(int id)
        {
            return studentDAO.DelStudents(id);
        }

        public List<Student> GetStudents()
        {
            return studentDAO.GetStudents();
        }

        public bool UpdateStudents(Student student)
        {
            return studentDAO.UpdateStudents(student);
        }
    }
}
