using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Class
{
    public string ClassId { get; set; } = null!;

    public int Quantity { get; set; }

    public float Price { get; set; }

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string TutorId { get; set; } = null!;

    public string StudentId { get; set; } = null!;

    public string SubjectId { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}
