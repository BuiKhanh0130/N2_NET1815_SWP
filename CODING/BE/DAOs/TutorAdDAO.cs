using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class TutorAdDAO
    {
        private readonly DbContext dbContext = null;
        public TutorAdDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddTutorAd(TutorAd ad)
        {
            dbContext.TutorAds.Add(ad);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelTutorAds(int id)
        {
            TutorAd ad = dbContext.TutorAds.Find(id);
            dbContext.TutorAds.Remove(ad);
            dbContext.SaveChanges();
            return true;
        }

        public List<TutorAd> GetTutorAds()
        {
            return dbContext.TutorAds.OrderByDescending(x => x.AdsId).ToList();
        }

        public bool UpdateTutorAds(TutorAd ad)
        {
            dbContext.TutorAds.Update(ad);
            dbContext.SaveChanges();
            return true;
        }
    }
}
