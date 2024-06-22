using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities.Comission;

public partial class Specialization
{
    public string SpecializationId { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<FormsEducationSpecialization> FormsEducationSpecializations { get; set; } = new List<FormsEducationSpecialization>();
}
