using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly GradeDAO gradeDAO = null;

        public GradeRepository()
        {
            if (gradeDAO == null)
            {
                gradeDAO = new GradeDAO();
            }
        }


        public bool AddGrade(Grade grade)
        {
            return gradeDAO.AddGrade(grade);
        }

        public bool DelGrades(int id)
        {
            return gradeDAO.DelGrades(id);
        }

        public List<Grade> GetGrades()
        {
            return gradeDAO.GetGrades();
        }

        public bool UpdateGrades(Grade grade)
        {
            return gradeDAO.UpdateGrades(grade);
        }

    }
}
