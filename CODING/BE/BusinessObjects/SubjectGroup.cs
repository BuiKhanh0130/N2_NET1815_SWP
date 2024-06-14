using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class SubjectGroup
{
    public string SubjectGroupId { get; set; } = null!;

    public string SubjectName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
