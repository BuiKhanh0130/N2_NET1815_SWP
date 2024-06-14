using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Feedback
{
    public string FeedbackId { get; set; } = null!;

    public DateOnly CreateDay { get; set; }

    public string Description { get; set; } = null!;

    public int Rate { get; set; }

    public bool IsActive { get; set; }

    public string StudentId { get; set; } = null!;

    public string TutorId { get; set; } = null!;

    public string ClassId { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}
