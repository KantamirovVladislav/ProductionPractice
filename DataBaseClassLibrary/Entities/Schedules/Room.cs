﻿using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities.Schedules;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int Capacity { get; set; }

    public string? Equipment { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
