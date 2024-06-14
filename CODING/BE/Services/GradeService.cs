using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository iGradeRepository = null;   

        public GradeService()
        {
            if (iGradeRepository == null)
            {
                iGradeRepository = new GradeRepository();
            }
        }
    
        public bool AddGrade(Grade grade)
        {
            return iGradeRepository.AddGrade(grade);
        }

        public bool DelGrades(int id)
        {
            return iGradeRepository.DelGrades(id);
        }

        public List<Grade> GetGrades()
        {
            return iGradeRepository.GetGrades();
        }

        public bool UpdateGrades(Grade grade)
        {
            return iGradeRepository.UpdateGrades(grade);
        }
    }
}
