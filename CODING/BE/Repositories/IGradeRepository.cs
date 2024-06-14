using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IGradeRepository
    {
        public bool AddGrade(Grade grade);

        public bool DelGrades(int id);

        public List<Grade> GetGrades();

        public bool UpdateGrades(Grade grade);
    }
}
