using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class Keysfordocument
{
    public int KeyId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Documentdatum> Documentdata { get; set; } = new List<Documentdatum>();
    
    public virtual ICollection<DocumentKey> DocumentKeys { get; set; } = new List<DocumentKey>();

    public virtual ICollection<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();

    public override string ToString()
    {
        return Name;
    }
}
