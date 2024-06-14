using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFeedbackService
    {
        public bool AddFeedback(Feedback feedback);

        public bool DelFeedbacks(int id);

        public List<Feedback> GetFeedbacks(string id);

        public bool UpdateFeedbacks(Feedback feedback);

        public double TotalStart(string id);

        public int TotalRate(string id);
    }
}
