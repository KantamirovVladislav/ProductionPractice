using System;
using System.Collections.Generic;

namespace DataBaseClassLibrary.Entities;

public partial class DocumentsImage
{
    public int DocumentId { get; set; }

    public int ApplicantId { get; set; }

    public int DocumentTypeId { get; set; }

    public string Photo { get; set; } = null!;

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<Documentdatum> Documentdata { get; set; } = new List<Documentdatum>();
}
