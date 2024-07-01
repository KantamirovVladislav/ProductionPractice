using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int Capacity { get; set; }

    public string Equipment { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
