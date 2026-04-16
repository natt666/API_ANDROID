using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class Document
{
    public int Id { get; set; }

    public int Nom { get; set; }

    public int TipusDocumentId { get; set; }

    public virtual TipusDocument IdNavigation { get; set; } = null!;

    public virtual ICollection<Oferte> Ofertes { get; set; } = new List<Oferte>();
}
