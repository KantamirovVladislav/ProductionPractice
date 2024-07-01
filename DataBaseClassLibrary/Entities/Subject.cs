using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<Specialtysubject> Specialtysubjects { get; set; } = new List<Specialtysubject>();
}
