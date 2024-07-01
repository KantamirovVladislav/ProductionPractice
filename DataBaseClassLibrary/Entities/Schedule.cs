using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int? GroupId { get; set; }

    public int? TeacherId { get; set; }

    public int? SpecialtySubjectId { get; set; }

    public int? RoomId { get; set; }

    public string AcademicYear { get; set; } = null!;

    public virtual Group? Group { get; set; }

    public virtual Room? Room { get; set; }

    public virtual ICollection<Scheduletimeslot> Scheduletimeslots { get; set; } = new List<Scheduletimeslot>();

    public virtual Specialtysubject? SpecialtySubject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
