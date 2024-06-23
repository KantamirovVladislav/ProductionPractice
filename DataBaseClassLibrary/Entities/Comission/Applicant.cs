using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Applicant
{
    public int ApplicantId { get; set; }

    public string FirstName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public DateOnly? DateRegistry { get; set; }

    public string Snils { get; set; } = null!;

    public DateOnly? Birthday { get; set; }

    public char? Gender { get; set; }

    public decimal? AverageScore { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<DocumentsImage> DocumentsImages { get; set; } = new List<DocumentsImage>();

    public virtual ICollection<FormsEducationSpecializationApplicant> FormsEducationSpecializationApplicants { get; set; } = new List<FormsEducationSpecializationApplicant>();

    public virtual ICollection<PersonalAccountdata> PersonalAccountData { get; set; } = new List<PersonalAccountdata>();

    public virtual Status? StatusNavigation { get; set; }
}
