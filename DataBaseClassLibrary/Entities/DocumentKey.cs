using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class DocumentKey
{
    public int IdKeys { get; set; }

    public int DocumentTypeId { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual Keysfordocument IdKeysNavigation { get; set; } = null!;
}
