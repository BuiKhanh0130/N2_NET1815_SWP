using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Grade
{
    public string GradeId { get; set; } = null!;

    public int Number { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
