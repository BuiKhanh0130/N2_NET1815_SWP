using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IComplaintService
    {
        public bool AddComplaint(Complaint complaint);

        public bool DelComplaints(int id);

        public List<Complaint> GetComplaints();

        public bool UpdateComplaints(Complaint complaint);
    }
}
