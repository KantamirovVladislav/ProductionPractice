using DataBaseClassLibrary.Entities.PersonalData;

namespace DataBaseClassLibrary.Entities.Comission;

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

    public string? Status { get; set; }

    public virtual ICollection<DocumentsImage> DocumentsImages { get; set; } = new List<DocumentsImage>();

    public virtual ICollection<FormsEducationSpecializationApplicant> FormsEducationSpecializationApplicants { get; set; } = new List<FormsEducationSpecializationApplicant>();

    public virtual ICollection<PersonalAccountData> PersonalAccountData { get; set; } = new List<PersonalAccountData>();
}
