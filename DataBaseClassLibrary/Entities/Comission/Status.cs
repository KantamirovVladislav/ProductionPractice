using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Status
{
    public int IdStatus { get; set; }

    public string Content { get; set; } = null!;

    public virtual ICollection<Applicant> Applicants { get; set; } = new List<Applicant>();

    public virtual ICollection<FormsEducationSpecializationApplicant> FormsEducationSpecializationApplicants { get; set; } = new List<FormsEducationSpecializationApplicant>();
}
