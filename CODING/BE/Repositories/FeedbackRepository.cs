using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDAO feedbackDAO = null;

        public FeedbackRepository()
        {
            if (feedbackDAO == null)
            {
                feedbackDAO = new FeedbackDAO();
            }
        }

        public bool AddFeedback(Feedback feedback)
        {
            return feedbackDAO.AddFeedback(feedback);
        }

        public bool DelFeedbacks(int id)
        {
            return feedbackDAO.DelFeedbacks(id);
        }

        public List<Feedback> GetFeedbacks(string id)
        {
            return feedbackDAO.GetFeedbacks(id);
        }

        public bool UpdateFeedbacks(Feedback feedback)
        {
            return feedbackDAO.UpdateFeedbacks(feedback);
        }
    }
}
