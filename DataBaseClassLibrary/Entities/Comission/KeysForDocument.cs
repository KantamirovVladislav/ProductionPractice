using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities.Comission;

public partial class KeysForDocument
{
    public string Name { get; set; } = null!;

    public virtual ICollection<DocumentKey> DocumentKeys { get; set; } = new List<DocumentKey>();
}
