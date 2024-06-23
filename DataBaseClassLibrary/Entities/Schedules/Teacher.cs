using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string FullName { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
