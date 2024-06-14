using BusinessObjects;
using DAOs;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository iFeedbackRepository = null;

        public FeedbackService()
        {
            if (iFeedbackRepository == null)
            {
                iFeedbackRepository = new FeedbackRepository();
            }
        }
        public bool AddFeedback(Feedback feedback)
        {
            return iFeedbackRepository.AddFeedback(feedback);
        }

        public bool DelFeedbacks(int id)
        {
            return iFeedbackRepository.DelFeedbacks(id);
        }

        public List<Feedback> GetFeedbacks(string id)
        {
            return iFeedbackRepository.GetFeedbacks(id);
        }

        public bool UpdateFeedbacks(Feedback feedback)
        {
            return iFeedbackRepository.UpdateFeedbacks(feedback);
        }

        public double TotalStart(string id)
        {
            var query = iFeedbackRepository.GetFeedbacks(id);
            double start = 0.00;
            if (query.Count() <= 0)
            {
                return 0;
            }
            else
            {
                start = query.Sum(x => x.Rate) / query.Count();
            }
            return start;
        }

        public int TotalRate(string id)
        {
            var query = iFeedbackRepository.GetFeedbacks(id);
            int rate = 0;
            if (query == null)
            {
                return 0;
            }
            rate = query.Count();
            return rate;
        }
    }
}
