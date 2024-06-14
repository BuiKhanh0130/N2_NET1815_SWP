using BusinessObjects;
using BusinessObjects.Models.TutorModel;
using DAOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repositories
{
    public class TutorRepository : ITutorRepository
    {
        private readonly TutorDAO tutorDAO = null;

        public TutorRepository()
        {
            if (tutorDAO == null)
            {
                tutorDAO = new TutorDAO();
            }
        }


        public bool AddTutor(Tutor tutor)
        {
            return tutorDAO.AddTutor(tutor);
        }

        public bool DelTutors(int id)
        {
            return tutorDAO.DelTutors(id);
        }

        public List<Tutor> GetTutors()
        {
            return tutorDAO.GetTutors();
        }

        public List<Subject> GetTutor(string id)
        {
            return tutorDAO.GetTutors(id);
        }

        public bool UpdateTutors(Tutor tutor)
        {
            return tutorDAO.UpdateTutors(tutor);
        }

        public IEnumerable<Tutor> Filter(RequestSearchTutorModel requestSearchTutorModel)
        {
            var allTutor = tutorDAO.GetTutors().Where(tu => tu.IsActive == true);

            //Trường hợp chọn loại bằng
            if (string.IsNullOrEmpty(requestSearchTutorModel.TypeOfDegree))
            {
                allTutor = tutorDAO.GetTutors().
                    Where(tu => tu.IsActive == true
                    && tu.HourlyRate >= requestSearchTutorModel.MinRate
                    && tu.HourlyRate <= requestSearchTutorModel.MaxRate);
            }
            //Trường KHÔNG hợp chọn loại bằng
            else
            {
                allTutor = tutorDAO.GetTutors().
                    Where(tu => tu.IsActive == true
                    && tu.HourlyRate >= requestSearchTutorModel.MinRate
                    && tu.HourlyRate <= requestSearchTutorModel.MaxRate
                    && tu.TypeOfDegree == requestSearchTutorModel.TypeOfDegree);
            }

            if (allTutor.Count() <= 0)
            {
                allTutor = null;
            }

            return allTutor;
        }

        public IEnumerable<ResponseSearchTutorModel> Sorting
            (IEnumerable<ResponseSearchTutorModel> query, 
            string? sortBy, 
            string? sortType,
            int pageIndex,
            int pageSize)
        {
            //_____SORT_____
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortTutorTypeEnum.Ascending.ToString() && sortBy == SortTutorByEnum.HourlyRate.ToString())
                {
                    query = query.OrderBy(t => t.HourlyRate);
                }
                else if (sortType == SortTutorTypeEnum.Descending.ToString() && sortBy == SortTutorByEnum.HourlyRate.ToString())
                {
                    query = query.OrderByDescending(t => t.HourlyRate);
                }
                else if (sortType == SortTutorTypeEnum.Ascending.ToString() && sortBy == SortTutorByEnum.Start.ToString())
                {
                    query = query.OrderBy(t => t.Start);
                }
                else if (sortType == SortTutorTypeEnum.Descending.ToString() && sortBy == SortTutorByEnum.Start.ToString())
                {
                    query = query.OrderByDescending(t => t.Start);
                }
            }
            else
            {
                query = query.OrderBy(t => t.HourlyRate);
            }

            //_____PAGING_____
            int validPageIndex = pageIndex > 0 ? pageIndex - 1 : 0;
            int validPageSize = pageSize > 0 ? pageSize : 10;

            query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);

            return query;
        }
    }
}
