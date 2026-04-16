using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class TipusTracking
{
    public int Id { get; set; }

    public string TipusNom { get; set; } = null!;

    public int? TrackingStepsId { get; set; }

    public virtual TrackingStep? TrackingSteps { get; set; }
}
