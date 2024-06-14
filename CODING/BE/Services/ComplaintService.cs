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
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository iComplaintRepository = null;

        public ComplaintService()
        {
            if (iComplaintRepository == null)
            {
                iComplaintRepository = new ComplaintRepository();
            }
        }

        public bool AddComplaint(Complaint complaint)
        {
            return iComplaintRepository.AddComplaint(complaint);
        }

        public bool DelComplaints(int id)
        {
            return iComplaintRepository.DelComplaints(id);
        }

        public List<Complaint> GetComplaints()
        {
            return iComplaintRepository.GetComplaints();
        }

        public bool UpdateComplaints(Complaint complaint)
        {
            return iComplaintRepository.UpdateComplaints(complaint);
        }
    }
}
