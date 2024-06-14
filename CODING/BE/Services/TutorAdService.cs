using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TutorAdService : ITutorAdService
    {
        private readonly ITutorAdRepository iTutorAdRepository = null;

        public TutorAdService()
        {
            if (iTutorAdRepository == null)
            {
                iTutorAdRepository = new TutorAdRepository();
            }
        }

        public bool AddTutorAd(TutorAd tutorAd)
        {
            return iTutorAdRepository.AddTutorAd(tutorAd);
        }

        public bool DelTutorAds(int id)
        {
            return iTutorAdRepository.DelTutorAds(id);
        }

        public List<TutorAd> GetTutorAds()
        {
            return iTutorAdRepository.GetTutorAds();
        }

        public bool UpdateTutorAds(TutorAd tutorAd)
        {
            return iTutorAdRepository.UpdateTutorAds(tutorAd);
        }
    }
}
