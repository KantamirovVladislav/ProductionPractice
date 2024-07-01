using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Commission
{
    public int CommissionId { get; set; }

    public string CommissionName { get; set; } = null!;

    public string? Description { get; set; }

    public int? HeadTeacherId { get; set; }

    public DateOnly? EstablishedDate { get; set; }

    public virtual Teacher? HeadTeacher { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
