using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class Solicitud
{
    public int Id { get; set; }

    public string MercanciaNombre { get; set; } = null!;

    public double PesBrut { get; set; }

    public double Volum { get; set; }

    public int ClientId { get; set; }

    public int OperadorId { get; set; }

    public int MercanciaTipus { get; set; }

    public int TipusTransportId { get; set; }

    public int TipusContenidorId { get; set; }

    public int OrigenId { get; set; }

    public int DestinoId { get; set; }

    public int IncotermId { get; set; }

    public int TipusFluxeId { get; set; }

    public int TipusCarregaId { get; set; }

    public virtual Usuari Client { get; set; } = null!;

    public virtual Ciutat Destino { get; set; } = null!;

    public virtual Incoterm Incoterm { get; set; } = null!;

    public virtual ICollection<Oferte> Ofertes { get; set; } = new List<Oferte>();

    public virtual Usuari Operador { get; set; } = null!;

    public virtual Ciutat Origen { get; set; } = null!;

    public virtual TipusCarrega TipusCarrega { get; set; } = null!;

    public virtual TipusContenidor TipusContenidor { get; set; } = null!;

    public virtual TipusFlux TipusFluxe { get; set; } = null!;

    public virtual TipusTransport TipusTransport { get; set; } = null!;
}
