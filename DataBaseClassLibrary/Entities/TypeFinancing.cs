using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class TypeFinancing
{
    public int TypeFinancingId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<FormsEducationSpecialization> FormsEducationSpecializations { get; set; } = new List<FormsEducationSpecialization>();
}
