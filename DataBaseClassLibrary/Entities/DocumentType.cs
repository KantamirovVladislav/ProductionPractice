using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class DocumentType
{
    public int DocumentTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DocumentKey> DocumentKeys { get; set; } = new List<DocumentKey>();

    public virtual ICollection<DocumentsImage> DocumentsImages { get; set; } = new List<DocumentsImage>();
}
