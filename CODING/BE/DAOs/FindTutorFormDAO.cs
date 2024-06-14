using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class FindTutorFormDAO
    {
        private readonly DbContext dbContext = null;
        public FindTutorFormDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddFindTutorForm(FindTutorForm form)
        {
            dbContext.FindTutorForms.Add(form);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelFindTutorForms(int id)
        {
            FindTutorForm form = dbContext.FindTutorForms.Find(id);
            dbContext.FindTutorForms.Remove(form);
            dbContext.SaveChanges();
            return true;
        }

        public List<FindTutorForm> GetFindTutorForms()
        {
            return dbContext.FindTutorForms.OrderByDescending(x => x.FormId).ToList();
        }

        public bool UpdateFindTutorForms(FindTutorForm form)
        {
            dbContext.FindTutorForms.Update(form);
            dbContext.SaveChanges();
            return true;
        }
    }
}
