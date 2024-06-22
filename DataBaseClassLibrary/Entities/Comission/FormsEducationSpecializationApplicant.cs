using System;
using System.Collections.Generic;
using DataBaseClassLibrary.Entities.Comission;

namespace DataBaseClassLibrary.Entities.Comission;

public partial class FormsEducationSpecializationApplicant
{
    public int ApplicantId { get; set; }

    public int FormsEducationId { get; set; }

    public string? Status { get; set; }

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual FormsEducationSpecialization FormsEducation { get; set; } = null!;
}
