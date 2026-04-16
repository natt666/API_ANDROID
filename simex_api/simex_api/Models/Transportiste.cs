using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class Transportiste
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int CiutatId { get; set; }

    public virtual Ciutat Ciutat { get; set; } = null!;

    public virtual ICollection<Oferte> OferteTransportistaDestinos { get; set; } = new List<Oferte>();

    public virtual ICollection<Oferte> OferteTransportistaOrigens { get; set; } = new List<Oferte>();
}
