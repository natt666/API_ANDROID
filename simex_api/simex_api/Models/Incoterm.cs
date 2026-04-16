using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class Incoterm
{
    public int Id { get; set; }

    public int TipusIncontermId { get; set; }

    public int TrackingStepsId { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; set; } = new List<Solicitud>();

    public virtual TipusIncoterm TipusInconterm { get; set; } = null!;

    public virtual TrackingStep TrackingSteps { get; set; } = null!;
}
