using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Tutor
{
    public string TutorId { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string Education { get; set; } = null!;

    public string TypeOfDegree { get; set; } = null!;

    public int CardId { get; set; }

    public float HourlyRate { get; set; }

    public string? Photo { get; set; }

    public string? Headline { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public string AccountId { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<TutorAd> TutorAds { get; set; } = new List<TutorAd>();

    public virtual ICollection<SubjectTutor> SubjectTutors { get; set; } = new List<SubjectTutor>();
}
