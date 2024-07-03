using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Applicantsandeducation
{
    public string? Snils { get; set; }

    public string? FirstName { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public double? AverageScore { get; set; }

    public int? Preferentialcount { get; set; }

    public string? SpecializationId { get; set; }

    public string? Specialityname { get; set; }

    public string? Finansingname { get; set; }

    public int? Priority { get; set; }

    public string? Statusname { get; set; }
}
