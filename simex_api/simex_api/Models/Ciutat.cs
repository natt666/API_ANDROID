using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class Ciutat
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int PaisId { get; set; }

    public virtual ICollection<LiniesTransportMaritim> LiniesTransportMaritims { get; set; } = new List<LiniesTransportMaritim>();

    public virtual Paisso Pais { get; set; } = null!;

    public virtual ICollection<Port> Ports { get; set; } = new List<Port>();

    public virtual ICollection<Solicitud> SolicitudDestinos { get; set; } = new List<Solicitud>();

    public virtual ICollection<Solicitud> SolicitudOrigens { get; set; } = new List<Solicitud>();

    public virtual ICollection<Transportiste> Transportistes { get; set; } = new List<Transportiste>();
}
