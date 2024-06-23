using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class FormsSpecialization
{
    public int FormEducationId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FormsEducationSpecialization> FormsEducationSpecializations { get; set; } = new List<FormsEducationSpecialization>();
}
