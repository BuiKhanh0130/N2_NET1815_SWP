using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class TutorDAO
    {
        private readonly DbContext dbContext = null;

        public TutorDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddTutor(Tutor tutor)
        {
            dbContext.Tutors.Add(tutor);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelTutors(int id)
        {
            Tutor tutor = dbContext.Tutors.Find(id);
            dbContext.Tutors.Remove(tutor);
            dbContext.SaveChanges();
            return true;
        }

        public List<Tutor> GetTutors()
        {
            return dbContext.Tutors.OrderByDescending(x => x.TutorId).ToList();
        }

        public List<Subject> GetTutors(string id)
        {
            

            return null;
        }
            
        public bool UpdateTutors(Tutor tutor)
        {
            dbContext.Tutors.Update(tutor);
            dbContext.SaveChanges();
            return true;
        }
    }
}
