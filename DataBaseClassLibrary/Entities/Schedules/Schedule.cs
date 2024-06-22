using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities.Schedules;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int GroupId { get; set; }

    public int TeacherId { get; set; }

    public int SubjectId { get; set; }

    public int RoomId { get; set; }

    public int TimeSlotId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;

    public virtual Timeslot TimeSlot { get; set; } = null!;
}
