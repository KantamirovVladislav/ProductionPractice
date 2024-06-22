using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities.Schedules;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public int SpecialtyId { get; set; }

    public int Course { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Specialty Specialty { get; set; } = null!;
}
