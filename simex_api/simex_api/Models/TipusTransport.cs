using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class TipusTransport
{
    public int Id { get; set; }

    public string Tipus { get; set; } = null!;

    public virtual ICollection<Oferte> Ofertes { get; set; } = new List<Oferte>();

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();
}
