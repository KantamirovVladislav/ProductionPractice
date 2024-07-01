using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Specialty
{
    public int SpecialtyId { get; set; }

    public string SpecialtyName { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Specialtysubject> Specialtysubjects { get; set; } = new List<Specialtysubject>();
}
