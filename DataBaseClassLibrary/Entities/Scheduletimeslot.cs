using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Scheduletimeslot
{
    public int ScheduleTimeSlotId { get; set; }

    public int? ScheduleId { get; set; }

    public int? TimeSlotId { get; set; }

    public virtual Schedule? Schedule { get; set; }

    public virtual Timeslot? TimeSlot { get; set; }
}
