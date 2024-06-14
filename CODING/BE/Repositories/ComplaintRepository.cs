using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly ComplaintDAO complaintDAO = null;

        public ComplaintRepository()
        {
            if (complaintDAO == null)
            {
                complaintDAO = new ComplaintDAO();
            }
        }

        public bool AddComplaint(Complaint complaint)
        {
            return complaintDAO.AddComplaint(complaint);
        }

        public bool DelComplaints(int id)
        {
            return complaintDAO.DelComplaints(id);
        }

        public List<Complaint> GetComplaints()
        {
            return complaintDAO.GetComplaints();
        }

        public bool UpdateComplaints(Complaint complaint)
        {
            return complaintDAO.UpdateComplaints(complaint);
        }
    }
}
