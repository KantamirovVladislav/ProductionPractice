using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Statusesforeducation
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FormsEducationSpecializationApplicant> FormsEducationSpecializationApplicants { get; set; } = new List<FormsEducationSpecializationApplicant>();

    public override string ToString()
    {
        return Name;
    }
}
