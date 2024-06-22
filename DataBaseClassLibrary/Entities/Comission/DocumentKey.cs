using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities.Comission;

public partial class DocumentKey
{
    public int DocumentKeyId { get; set; }

    public string Name { get; set; } = null!;

    public int DocumentTypeId { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<DocumentData> Documentdata { get; set; } = new List<DocumentData>();

    public virtual KeysForDocument NameNavigation { get; set; } = null!;
}
