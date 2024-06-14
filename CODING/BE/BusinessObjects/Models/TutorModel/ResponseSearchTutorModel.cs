using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models.TutorModel
{
    public class ResponseSearchTutorModel
    {
        public string TutorID { get; set; }
        public string FullName { get; set; }
        public string Photo { get; set; }
        public double HourlyRate { get; set; }
        public double Start { get; set; }
        public int Ratings { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }

        public string TopFeedback { get; set; }
    }
}
