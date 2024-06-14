using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TutorAdRepository : ITutorAdRepository
    {
        private readonly TutorAdDAO tutorAdDAO = null;

        public TutorAdRepository()
        {
            if (tutorAdDAO == null)
            {
                tutorAdDAO = new TutorAdDAO();
            }
        }

        public bool AddTutorAd(TutorAd tutorAd)
        {
            return tutorAdDAO.AddTutorAd(tutorAd);
        }

        public bool DelTutorAds(int id)
        {
            return tutorAdDAO.DelTutorAds(id);
        }

        public List<TutorAd> GetTutorAds()
        {
            return tutorAdDAO.GetTutorAds();
        }

        public bool UpdateTutorAds(TutorAd tutorAd)
        {
            return tutorAdDAO.UpdateTutorAds(tutorAd);
        }
    }
}
