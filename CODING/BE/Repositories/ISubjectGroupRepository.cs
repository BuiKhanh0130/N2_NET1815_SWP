using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISubjectGroupRepository
    {
        public bool AddSubjectGroup(SubjectGroup subjectGroup);

        public bool DelSubjectGroups(int id);

        public List<SubjectGroup> GetSubjectGroups();

        public bool UpdateSubjectGroups(SubjectGroup subjectGroup);
    }
}
