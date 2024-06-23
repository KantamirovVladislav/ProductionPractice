using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Educationbase
{
    public int BaseId { get; set; }

    public string Content { get; set; } = null!;

    public virtual ICollection<FormsEducationSpecialization> FormsEducationSpecializations { get; set; } = new List<FormsEducationSpecialization>();
}
