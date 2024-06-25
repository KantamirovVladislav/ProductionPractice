using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Applicantsandeducation
{
    public string? Snils { get; set; }

    public string? FirstName { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public decimal? AverageScore { get; set; }

    public int? Applicantsstatus { get; set; }

    public int? FormsEducationId { get; set; }

    public int? Status { get; set; }
}
