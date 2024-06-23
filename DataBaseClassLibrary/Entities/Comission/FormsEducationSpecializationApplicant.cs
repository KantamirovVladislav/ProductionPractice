using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class FormsEducationSpecializationApplicant
{
    public int ApplicantId { get; set; }

    public int FormsEducationId { get; set; }

    public int? Status { get; set; }

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual FormsEducationSpecialization FormsEducation { get; set; } = null!;

    public virtual Status? StatusNavigation { get; set; }
}
