using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IStudentService
    {
        public bool AddStudent(Student student);

        public bool DelStudents(int id);

        public List<Student> GetStudents();

        public bool UpdateStudents(Student student);
    }
}
