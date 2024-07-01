using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Statusesforapplicant
{
    public int IdStatus { get; set; }

    public string Content { get; set; } = null!;

    public bool Ispreferential { get; set; }

    public virtual ICollection<Statusesapplicant> Statusesapplicants { get; set; } = new List<Statusesapplicant>();
}
