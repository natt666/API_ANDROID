using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class TipusDocument
{
    public int Id { get; set; }

    public int TipusDocument1 { get; set; }

    public virtual Document? Document { get; set; }
}
