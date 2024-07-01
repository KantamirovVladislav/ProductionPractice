using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Specialtysubject
{
    public int SpecialtySubjectId { get; set; }

    public int? SpecialtyId { get; set; }

    public int? SubjectId { get; set; }

    public int Semester { get; set; }

    public int TotalHours { get; set; }

    public int LabHours { get; set; }

    public string Assessment { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Specialty? Specialty { get; set; }

    public virtual Subject? Subject { get; set; }
}
