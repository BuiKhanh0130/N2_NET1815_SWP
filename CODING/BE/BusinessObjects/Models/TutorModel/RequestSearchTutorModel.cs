using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models.TutorModel
{
    public class RequestSearchTutorModel
    {
        public string Search { get; set; }
        public double? MaxRate { get; set; } = 150;
        public double? MinRate { get; set; } = 10;
        public string? GradeId { get; set; }
        public string? TypeOfDegree { get; set; }
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public SortContent? SortContent { get; set; }
    }

    public class SortContent
    {
        public SortTutorByEnum sortTutorBy { get; set; }
        public SortTutorTypeEnum sortTutorType { get; set; }
    }

    public enum SortTutorByEnum
    {
        HourlyRate = 1,
        Start = 2,
    }
    public enum SortTutorTypeEnum
    {
        Ascending = 1,
        Descending = 2,
    }
}
