using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SubjectGroupService : ISubjectGroupService
    {
        private readonly ISubjectGroupRepository iSubjectGroupRepository = null;

        public SubjectGroupService()
        {
            if (iSubjectGroupRepository == null)
            {
                iSubjectGroupRepository = new SubjectGroupRepository();
            }
        }

        public bool AddSubjectGroup(SubjectGroup subjectGroup)
        {
            return iSubjectGroupRepository.AddSubjectGroup(subjectGroup);
        }

        public bool DelSubjectGroups(int id)
        {
            return iSubjectGroupRepository.DelSubjectGroups(id);
        }

        public List<SubjectGroup> GetSubjectGroups()
        {
            return iSubjectGroupRepository.GetSubjectGroups();
        }

        public bool UpdateSubjectGroups(SubjectGroup subjectGroup)
        {
            return iSubjectGroupRepository.UpdateSubjectGroups(subjectGroup);
        }
    }
}
