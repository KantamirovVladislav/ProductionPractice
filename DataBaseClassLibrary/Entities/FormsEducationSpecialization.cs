using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class FormsEducationSpecialization
{
    public int FormsEducationId { get; set; }

    public string SpecializationId { get; set; } = null!;

    public int FormEducation { get; set; }

    public int TypeFinancing { get; set; }

    public int EducationBase { get; set; }

    public DateOnly DateEnrollment { get; set; }

    public int? CountPlaces { get; set; }

    public virtual Educationbase EducationBaseNavigation { get; set; } = null!;

    public virtual FormsSpecialization FormEducationNavigation { get; set; } = null!;

    public virtual ICollection<FormsEducationSpecializationApplicant> FormsEducationSpecializationApplicants { get; set; } = new List<FormsEducationSpecializationApplicant>();

    public virtual Specialization Specialization { get; set; } = null!;

    public virtual TypeFinancing TypeFinancingNavigation { get; set; } = null!;
}
