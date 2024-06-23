using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Timeslot
{
    public int TimeSlotId { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
