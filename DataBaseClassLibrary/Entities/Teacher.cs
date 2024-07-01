using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string FullName { get; set; } = null!;

    public int? CommissionId { get; set; }

    public virtual Commission? Commission { get; set; }

    public virtual ICollection<Commission> Commissions { get; set; } = new List<Commission>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
