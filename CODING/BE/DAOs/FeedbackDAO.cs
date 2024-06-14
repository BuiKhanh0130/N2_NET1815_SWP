using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class FeedbackDAO
    {
        private readonly DbContext dbContext = null;

        public FeedbackDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddFeedback(Feedback feedback)
        {
            dbContext.Feedbacks.Add(feedback);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelFeedbacks(int id)
        {
            Feedback tutor = dbContext.Feedbacks.Find(id);
            dbContext.Feedbacks.Remove(tutor);
            dbContext.SaveChanges();
            return true;
        }

        public List<Feedback> GetFeedbacks(string id)
        {
            return dbContext.Feedbacks.Where(x => x.TutorId == id).ToList();
        }

        public bool UpdateFeedbacks(Feedback feedback)
        {
            dbContext.Feedbacks.Update(feedback);
            dbContext.SaveChanges();
            return true;
        }
    }
}
