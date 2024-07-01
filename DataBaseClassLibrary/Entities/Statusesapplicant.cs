using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Statusesapplicant
{
    public int Idapplicants { get; set; }

    public int Idstatuses { get; set; }

    public virtual Applicant IdapplicantsNavigation { get; set; } = null!;

    public virtual Statusesforapplicant IdstatusesNavigation { get; set; } = null!;
}
