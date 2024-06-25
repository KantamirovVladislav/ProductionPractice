using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Keysfordocument
{
    public int KeyId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DocumentData> Documentdata { get; set; } = new List<DocumentData>();

    public virtual ICollection<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();
}
