using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SubjectGroupRepository : ISubjectGroupRepository
    {
        private readonly SubjectGroupDAO subjectGroupDAO = null;

        public SubjectGroupRepository()
        {
            if (subjectGroupDAO == null)
            {
                subjectGroupDAO = new SubjectGroupDAO();
            }
        }

        public bool AddSubjectGroup(SubjectGroup subjectGroup)
        {
            return subjectGroupDAO.AddSubjectGroup(subjectGroup);
        }

        public bool DelSubjectGroups(int id)
        {
            return subjectGroupDAO.DelSubjectGroups(id);
        }

        public List<SubjectGroup> GetSubjectGroups()
        {
            return subjectGroupDAO.GetSubjectGroups();
        }

        public bool UpdateSubjectGroups(SubjectGroup subjectGroup)
        {
            return subjectGroupDAO.UpdateSubjectGroups(subjectGroup);
        }
    }
}
