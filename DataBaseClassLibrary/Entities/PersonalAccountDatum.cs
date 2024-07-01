using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class PersonalAccountDatum
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? Applicants { get; set; }

    public virtual Applicant? ApplicantsNavigation { get; set; }
}
