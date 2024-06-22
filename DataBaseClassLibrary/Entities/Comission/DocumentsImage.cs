using System;
using System.Collections.Generic;
using DataBaseClassLibrary.Entities.Comission;

namespace DataBaseClassLibrary.Entities.Comission;

public partial class DocumentsImage
{
    public int DocumentId { get; set; }

    public int ApplicantId { get; set; }

    public int DocumentTypeId { get; set; }

    public byte[] Photo { get; set; } = null!;

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<DocumentData> Documentdata { get; set; } = new List<DocumentData>();
}
