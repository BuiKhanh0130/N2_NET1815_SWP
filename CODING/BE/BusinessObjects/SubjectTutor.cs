using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects;

    public partial class SubjectTutor
    {
        public string SubjectId { get; set; } = null!;

        public string TutorId { get; set; } = null!;

        public bool IsActive { get; set; }

        public virtual Subject Subject { get; set; } = null!;

        public virtual Tutor Tutor { get; set; } = null!;
    }

