using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class DocumentType
{
    public int DocumentTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DocumentsImage> DocumentsImages { get; set; } = new List<DocumentsImage>();

    public virtual ICollection<Keysfordocument> IdKeys { get; set; } = new List<Keysfordocument>();
}
