﻿using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities.Comission;

public partial class DocumentData
{
    public int DocumentDataId { get; set; }

    public int DocumentId { get; set; }

    public int DocumentKeyId { get; set; }

    public string DataValue { get; set; } = null!;

    public virtual DocumentsImage Document { get; set; } = null!;

    public virtual DocumentKey DocumentKey { get; set; } = null!;
}
