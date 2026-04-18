using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class TrackingHistory
{
    public int Id { get; set; }

    public int OfertaId { get; set; }

    public int TrackingStepId { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual Oferte Oferta { get; set; } = null!;

    public virtual TrackingStep TrackingStep { get; set; } = null!;
}
