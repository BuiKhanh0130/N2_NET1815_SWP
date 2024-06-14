using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class FindTutorFormRepository : IFindTutorFormRepository
    {
        private readonly FindTutorFormDAO findTutorFormDAO = null;

        public FindTutorFormRepository()
        {
            if (findTutorFormDAO == null)
            {
                findTutorFormDAO = new FindTutorFormDAO();
            }
        }

        public bool AddFindTutorForm(FindTutorForm form)
        {
            return findTutorFormDAO.AddFindTutorForm(form);
        }

        public bool DelFindTutorForms(int id)
        {
            return findTutorFormDAO.DelFindTutorForms(id);
        }

        public List<FindTutorForm> GetFindTutorForms()
        {
            return findTutorFormDAO.GetFindTutorForms();
        }

        public bool UpdateFindTutorForms(FindTutorForm form)
        {
            return findTutorFormDAO.UpdateFindTutorForms(form);
        }
    }
}
