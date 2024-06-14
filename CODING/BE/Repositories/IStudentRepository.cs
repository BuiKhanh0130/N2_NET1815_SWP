using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStudentRepository
    {
        public bool AddStudent(Student student);

        public bool DelStudents(int id);

        public List<Student> GetStudents();

        public bool UpdateStudents(Student student);
    }
}
