using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class ComplaintDAO
    {
        private readonly DbContext dbContext = null;
        public ComplaintDAO()
        {
            if (dbContext == null)
            {
                dbContext = new DbContext();
            }
        }

        public bool AddComplaint(Complaint complaint)
        {
            dbContext.Complaints.Add(complaint);
            dbContext.SaveChanges();
            return true;
        }

        public bool DelComplaints(int id)
        {
            Complaint complaint = dbContext.Complaints.Find(id);
            dbContext.Complaints.Remove(complaint);
            dbContext.SaveChanges();
            return true;
        }

        public List<Complaint> GetComplaints()
        {
            return dbContext.Complaints.OrderByDescending(x => x.ComplaintId).ToList();
        }

        public bool UpdateComplaints(Complaint complaint)
        {
            dbContext.Complaints.Update(complaint);
            dbContext.SaveChanges();
            return true;
        }
    }
}
