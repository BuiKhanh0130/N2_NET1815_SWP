using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Subject
{
    public string SubjectId { get; set; } = null!;

    public string GradeId { get; set; } = null!;

    public string SubjectGroupId { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<FindTutorForm> FindTutorForms { get; set; } = new List<FindTutorForm>();

    public virtual Grade Grade { get; set; } = null!;

    public virtual SubjectGroup SubjectGroup { get; set; } = null!;

    public virtual ICollection<SubjectTutor> SubjectTutors { get; set; } = new List<SubjectTutor>();
}
