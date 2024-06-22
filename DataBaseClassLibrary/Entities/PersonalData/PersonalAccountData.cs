using DataBaseClassLibrary.Entities.Comission;

namespace DataBaseClassLibrary.Entities.PersonalData;

public partial class PersonalAccountData
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? Applicants { get; set; }

    public virtual Applicant? ApplicantsNavigation { get; set; }
}
