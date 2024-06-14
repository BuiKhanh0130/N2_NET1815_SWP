using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Complaint
{
    public string ComplaintId { get; set; } = null!;

    public DateOnly CreateDay { get; set; }

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public string TutorId { get; set; } = null!;

    public string StudentId { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}
