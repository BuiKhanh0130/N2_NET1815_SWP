using BusinessObjects;
using BusinessObjects.Models.TutorModel;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _repository;

        public TutorService()
        {
            _repository = new TutorRepository();
        }

        public bool AddTutor(Tutor tutor)
        {
            return _repository.AddTutor(tutor);
        }

        public bool DelTutors(int id)
        {
            return _repository.DelTutors(id);
        }

        public IEnumerable<Tutor> Filter(RequestSearchTutorModel requestSearchTutorModel)
        {
            return _repository.Filter(requestSearchTutorModel);
        }

        public List<Subject> GetTutor(string id)
        {
            return _repository.GetTutor(id);
        }

        public List<Tutor> GetTutors()
        {
            return _repository.GetTutors();
        }

        public IEnumerable<ResponseSearchTutorModel> Sorting(IEnumerable<ResponseSearchTutorModel> query, string? sortBy, string? sortType, int pageIndex, int pageSize)
        {
            return _repository.Sorting(query, sortBy, sortType, pageIndex, pageSize);
        }

        public bool UpdateTutors(Tutor tutor)
        {
            return _repository.UpdateTutors(tutor);
        }
    }
}
