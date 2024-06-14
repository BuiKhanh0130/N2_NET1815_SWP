using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository iStudentRepository = null;

        public StudentService()
        {
            if (iStudentRepository == null)
            {
                iStudentRepository = new StudentRepository();
            }
        }

        public bool AddStudent(Student student)
        {
            return iStudentRepository.AddStudent(student);
        }

        public bool DelStudents(int id)
        {
            return iStudentRepository.DelStudents(id);
        }

        public List<Student> GetStudents()
        {
            return iStudentRepository.GetStudents();
        }

        public bool UpdateStudents(Student student)
        {
            return iStudentRepository.UpdateStudents(student);
        }
    }
}
