using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITutorAdService
    {
        public bool AddTutorAd(TutorAd tutorAd);

        public bool DelTutorAds(int id);

        public List<TutorAd> GetTutorAds();

        public bool UpdateTutorAds(TutorAd tutorAd);
    }
}
